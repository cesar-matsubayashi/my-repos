import { createContext, useState, useContext, type ReactNode } from "react";
import type { RepositoryResponse, SearchResponse } from "../utils/api";
import api from "../utils/api";

interface RepositoryContextType {
  repositoryList: RepositoryResponse[];
  myRepositoryList: RepositoryResponse[];
  favoritesList: RepositoryResponse[];
  searchList: SearchResponse;
  searchValue: string, 
  setSearchValue: (value: string) => void;
  addRepository: (repositoryUrl: string) => Promise<void>;
  myRepositories: () => Promise<void>;
  myFavorites: () => Promise<void>;
  changeFavoriteStatus: (status: boolean) => Promise<void>;
  searchRepositories: (keyword: string, page: number) => Promise<void>;
}

const RepositoryContext = createContext<RepositoryContextType | undefined>(
  undefined
);

export default function RepositoryProvider({ children }: { children: ReactNode }) {
  const [repositoryList, setRepositoryList] = useState<RepositoryResponse[]>([]);
  const [myRepositoryList, setMyRepositoryList] = useState<RepositoryResponse[]>([]);
  const [favoritesList, setFavoritesList] = useState<RepositoryResponse[]>([]);
  const [searchList, setSearchList] = useState<SearchResponse>({
      totalCount: 0,
      projects: [],
    });
  const [searchValue, setSearchValue] = useState<string>("");

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
      const repositories: RepositoryResponse[] = await api.myRepositories();
      setMyRepositoryList(repositories);
    } catch (error) {
      console.error("Failed to create repository:", error);
    }
  };

  const changeFavoriteStatus = async (status: boolean): Promise<void> => {
    try {
      const repository: RepositoryResponse = await api.changeFavoriteStatus(status);
      
      if (status){
        setFavoritesList((prevList) => [...prevList, repository]);
      } else {
        setFavoritesList((prevList) => prevList.filter(
          repo => repo.id !== repository.id))
      }
      
    } catch (error) {
      console.error("Failed to create repository:", error);
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
      myRepositoryList, 
      myRepositories, 
      favoritesList, 
      myFavorites,
      changeFavoriteStatus,
      searchList,
      searchRepositories,
      searchValue, 
      setSearchValue }}>
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