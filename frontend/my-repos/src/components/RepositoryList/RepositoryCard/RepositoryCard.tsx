import "./RepositoryCard.css";
import type { GithubRepositoryResponse, RepositoryResponse } from "../../../utils/api";
import { useRepository } from "../../../contexts/RepositoryContext";
import { useModal } from "../../../contexts/ModalContext";
import type React from "react";

type RepositoryCardProps = {
  repository: (RepositoryResponse | GithubRepositoryResponse);
};

export default function RepositoryCard({ repository }: RepositoryCardProps) {
  const { changeFavoriteStatus, changeGithubResponseFavorite } = useRepository();
  const { setOpen, setRepository } = useModal();
  
  const favoriteIcon = (filled: boolean) => {
    const color: string = "#1c6b2b"

    const handleFavorite = (e: React.MouseEvent<HTMLOrSVGElement>) => {
      e.stopPropagation();
      const isStored = 'id' in repository;

      if (isStored){
        changeFavoriteStatus(repository);
      } else {
        changeGithubResponseFavorite(repository);
      };
    }

    return (
      <svg
        className="repository__favorite-icon" 
        onClick={handleFavorite}
        width="24"
        height="24"
        viewBox="0 0 24 24"
        fill={filled ? color : "none"}
        stroke={filled ? color : "#575757"}
        strokeWidth="1"
        strokeLinecap="round"
        strokeLinejoin="round"
        aria-hidden="true"
        style={{cursor: "pointer"}}
      >
        <polygon className="repository__favorite-icon" 
          points="12 2 15 10 23 10 17 14 19 22 12 17 5 22 7 14 1 10 9 10" />
      </svg>
    );
  }

   const handleClick = () => {
      setRepository(repository);
      setOpen(true);
    }

  return (
    <div className="repository-card" onClick={handleClick}>
      <div className="repository-card__header">
        <h2 className="repository-card__name">{repository.name}</h2>
        {favoriteIcon(repository.isFavorite)}
      </div>
      <p className="repository-card__description">{repository.description}</p>
      <div className="repository-card__bottom">
        <div className="repository-card__language">
          {repository.language}
        </div>
        <div className="repository-card__owner">
          Owner: {repository.owner}
        </div>
      </div>
    </div>
  );
}
