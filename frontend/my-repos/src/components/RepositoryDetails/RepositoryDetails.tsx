import './RepositoryDetails.css'
import { useModal } from "../../contexts/ModalContext";
import { useRepository } from '../../contexts/RepositoryContext';
import { useEffect } from 'react';
import ReactMarkdown from 'react-markdown';

export default function RepositoryDetails() {
  const { repository } = useModal()
  const { getReadme, readme } = useRepository();

  if (!repository) return;
  
  useEffect(() => {
    getReadme(repository.owner, repository.name);
  }, [])

  const binary = Uint8Array.from(atob(readme.content), c => c.charCodeAt(0));
  const decoded = new TextDecoder().decode(binary);
  
  return (
    <div className="details">
      <div className="details__readme">
        <ReactMarkdown>{decoded}</ReactMarkdown>
      </div>
      <div className="details__info">
        <div className="details__header">
          <h2 className="details__name">{repository.name}</h2>
        </div>
        <p className="details__description">{repository.description}</p>
        <p className="details__updated">
          Last Updated: 
          {new Date(repository.updatedDateTime).toLocaleDateString("en-US", {
            year: "numeric",
            month: "short",
            day: "numeric",
          })}
        </p>
        <div className="details__bottom">
          <div className="details__owner">
            Owner: {repository.owner}
          </div>
          <div>
            <p>Languages:</p>
            <div className="details__language">
              {repository.language}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}