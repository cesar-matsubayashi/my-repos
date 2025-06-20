import "./RepositoryCard.css";
import type { RepositoryResponse } from "../../../utils/api";

type RepositoryCardProps = {
  repository: RepositoryResponse;
};

export default function RepositoryCard({ repository }: RepositoryCardProps) {

  return (
    <div className="repository-card" id={repository.id}>
      <h2 className="repository-card__name">{repository.name}</h2>
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
