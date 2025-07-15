import './RepositoryDetails.css'
import { useModal } from "../../contexts/ModalContext";

export default function RepositoryDetails() {
  const { repository } = useModal()
 
  if (!repository) return;

  return (
    <div className="details">
      <div className="details__readme">MyRepos
MyRepos é uma aplicação web que permite aos usuários pesquisar repositórios no GitHub, salvar seus repositórios favoritos e gerenciar suas próprias coleções. Basta colar o link de um repositório do GitHub para começar!

Funcionalidades
Pesquisa de repositórios por nome usando a API do GitHub
Adição de repositórios por URL
Marcar/desmarcar repositórios como favoritos
Listar todos os repositórios adicionados
Persistência local (em breve com autenticação)
Paginação de resultados
Interface amigável com React + TypeScript
Como executar
Frontend (React + Vite + TypeScript)
# Instalar dependências
cd frontend
npm install

# Arquivo .env
cp .env.example .env

# edite o .env com a URL da sua API, por exemplo:
VITE_API_URL=https://localhost:7174

# Iniciar servidor de desenvolvimento
npm run dev
Backend (ASP.NET Core)
cd backend/MyRepos.Api
dotnet run
Tecnologias
Frontend:
React
TypeScript
React Router
Vite
Context API
Backend:
ASP.NET Core
Entity Framework InMemory
Mapster
MediatR
CORS habilitado
Funcionalidades futuras
Autenticação e cadastro
Salvamento persistente de dados
Mostrar README na página de detalhes
Mostar contribuidores
Autenticação API GitHub</div>
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