const repository =  {
  id: "69151732-ea8d-4715-952e-c89e4930f6d4",
  githubId: 1004628223,
  name: "my-repos",
  description: "Allows you to create a catalog of your projects and mark repositories as favorites",
  language: "C#",
  updatedDateTime: "2025-06-30T22:51:58+00:00",
  owner: "cesar-matsubayashi",
  repositoryUrl: "https://github.com/cesar-matsubayashi/my-repos",
  isFavorite: false
}

export default function RepositoryDetails() {

  return (
    <div className="details">
      <div className="details__readme"></div>
      <div className="details__info">
        <div className="details__header">
          <h2 className="details__name">{repository.name}</h2>
        </div>
        <p className="details__description">{repository.description}</p>
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