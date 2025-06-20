import { createContext, useState, useContext, type ReactNode } from "react";
import type { RepositoryResponse } from "../utils/api";
import api from "../utils/api";

interface RepositoryContextType {
  repositoryList: RepositoryResponse[];
  myRepositoryList: RepositoryResponse[];
  addRepository: (repositoryUrl: string) => Promise<void>;
  myRepositories: () => Promise<void>;
}

const RepositoryContext = createContext<RepositoryContextType | undefined>(
  undefined
);

export default function RepositoryProvider({ children }: { children: ReactNode }) {
  const [repositoryList, setRepositoryList] = useState<RepositoryResponse[]>([]);
  const [myRepositoryList, setMyRepositoryList] = useState<RepositoryResponse[]>([]);

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

  return (
    <RepositoryContext.Provider value={{ repositoryList, addRepository, myRepositoryList, myRepositories }}>
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