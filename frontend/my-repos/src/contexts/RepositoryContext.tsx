import { createContext, useState, useContext, type ReactNode } from "react";
import type { RepositoryResponse, SearchResponse, GithubRepositoryResponse } from "../utils/api";
import api from "../utils/api";

interface RepositoryContextType {
  repositoryList: RepositoryResponse[];
  githubRepositoryList: GithubRepositoryResponse[];
  favoritesList: RepositoryResponse[];
  searchList: SearchResponse;
  searchValue: string, 
  setSearchValue: (value: string) => void;
  addRepository: (repositoryUrl: string) => Promise<void>;
  getRepositories: () => Promise<void>;
  myRepositories: () => Promise<void>;
  myFavorites: () => Promise<void>;
  changeFavoriteStatus: (repository: RepositoryResponse) => Promise<void>;
  changeGithubResponseFavorite: (repository: GithubRepositoryResponse) => Promise<void>;
  searchRepositories: (keyword: string, page: number) => Promise<void>;
}

const RepositoryContext = createContext<RepositoryContextType | undefined>(
  undefined
);

export default function RepositoryProvider({ children }: { children: ReactNode }) {
  const [repositoryList, setRepositoryList] = useState<RepositoryResponse[]>([]);
  const [favoritesList, setFavoritesList] = useState<RepositoryResponse[]>([]);
  const [searchList, setSearchList] = useState<SearchResponse>({
      totalCount: 0,
      projects: [],
    });
  const [githubRepositoryList, setGithubRepositoryList] = 
    useState<GithubRepositoryResponse[]>([]);
  const [searchValue, setSearchValue] = useState<string>("");

  const getRepositories = async (): Promise<void> => {
    try {
      const repositories: RepositoryResponse[] = await api.repositories();
      setRepositoryList(repositories);
    } catch (error) {
      console.error("Failed to get repositories:", error);
    }
  }

  const addRepository = async (repositoryUrl: string): Promise<void> => {
    try {
      const newRepo: RepositoryResponse = await api.create(repositoryUrl);
      setRepositoryList((prevList) => [...prevList, newRepo]);
    } catch (error) {
      console.error("Failed to create repository:", error);
    }
  };
  
  const myRepositories = async (): Promise<void> => {
    try {
      const repositories: GithubRepositoryResponse[] = await api.myRepositories();
      setGithubRepositoryList(repositories);
    } catch (error) {
      console.error("Failed to get user repositories:", error);
    }
  };
  
  const changeFavoriteStatus = async (repository: RepositoryResponse): Promise<void> => {
    try {
      const updated: RepositoryResponse = 
        await api.changeFavoriteStatus(repository.id, !repository.isFavorite);
      
      if (updated.isFavorite){
        setFavoritesList((prevList) => [...prevList, updated]);
      } else {
        setFavoritesList((prevList) => prevList.filter(
          repo => repo.id !== updated.id))        
      }
        
      setRepositoryList((prevList) => 
        prevList.map((r) => r.id === updated.id ? updated : r)
      )
    } catch (error) {
      console.error("Failed to update favorite status repository:", error);
    }
  };

  const changeGithubResponseFavorite = async (repository: GithubRepositoryResponse): Promise<void> => {
    try{
      let repo = repositoryList.find((r) => r.repositoryUrl == repository.repositoryUrl); 
      
      if(!repo){
        repo = await api.create(repository.repositoryUrl);
      }

      changeFavoriteStatus(repo);

      repository.isFavorite = !repository.isFavorite;
      setGithubRepositoryList((prevList) => 
      prevList.map((r) => r.repositoryUrl === repository.repositoryUrl ? repository : r));

    } catch (error) {
      console.error("Failed to favorite repository:", error);
      return;
    } 
  };
  
  const myFavorites = async (): Promise<void> => {
    try {
      const repositories: RepositoryResponse[] = await api.myFavorites();
      setFavoritesList(repositories);
    } catch (error) {
      console.error("Failed to create repository:", error);
    }
  };

  const searchRepositories = async (keyword: string, page: number = 1 ): Promise<void> => {
    try {
      const repositories: SearchResponse = await api.searchRepositories(keyword, page);
      setSearchList(repositories);
      console.log(repositories);
    } catch (error) {
      console.error("Failed to create repository:", error);
    }
  };

  return (
    <RepositoryContext.Provider value={{ 
      repositoryList, 
      addRepository, 
      githubRepositoryList, 
      myRepositories, 
      favoritesList, 
      myFavorites,
      changeFavoriteStatus,
      changeGithubResponseFavorite,
      searchList,
      searchRepositories,
      searchValue, 
      setSearchValue,
      getRepositories }}>
      {children}
    </RepositoryContext.Provider>
  );
};

export const useRepository = (): RepositoryContextType => {
  const context = useContext(RepositoryContext);
  
  if (!context) {
    throw new Error("useRepository must be used within a RepositoryProvider");
  }

  return context;
};