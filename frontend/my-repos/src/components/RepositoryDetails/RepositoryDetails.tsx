import './RepositoryDetails.css'
import { useModal } from "../../contexts/ModalContext";

export default function RepositoryDetails() {
  const { repository } = useModal()
 
  if (!repository) return;

  return (
    <div className="details">
      <div className="details__readme"></div>
      <div className="details__info">
        <div className="details__header">
          <h2 className="details__name">{repository.name}</h2>
        </div>
        <p className="details__description">{repository.description}</p>
        <p className="details__updated">
          {new Date(repository.updatedDateTime).toLocaleDateString("en-US", {
            year: "numeric",
            month: "short",
            day: "numeric",
          })}
        </p>
        <div className="details__bottom">
          <div className="details__language">
            {repository.language}
          </div>
          <div className="details__owner">
            Owner: {repository.owner}
          </div>
        </div>
      </div>
    </div>
  );
}