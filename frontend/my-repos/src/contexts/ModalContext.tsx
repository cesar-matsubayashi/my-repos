import { createContext, useState, useContext, type ReactNode } from "react";
import type { BaseRepository, RepositoryResponse } from "../utils/api";

interface ModalContextType {
  open: boolean;
  setOpen: (value: boolean) => void;
  repository?: BaseRepository;
  setRepository: (value: BaseRepository) => void;
}

const ModalContext = createContext<ModalContextType | undefined>(
  undefined
);

export default function ModalProvider({ children }: { children: ReactNode }) {
  const [open, setOpen] = useState<boolean>(false);
  const [repository, setRepository] = useState<BaseRepository>();

  return (
    <ModalContext.Provider value={{ 
      open,
      setOpen,
      repository,
      setRepository }}>
      {children}
    </ModalContext.Provider>
  );
};

export const useModal = (): ModalContextType => {
  const context = useContext(ModalContext);
  
  if (!context) {
    throw new Error("useModal must be used within a ModalProvider");
  }

  return context;
};