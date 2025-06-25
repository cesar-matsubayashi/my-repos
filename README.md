# MyRepos

MyRepos é uma aplicação web que permite aos usuários pesquisar repositórios no GitHub, salvar seus repositórios favoritos e gerenciar suas próprias coleções. Basta colar o link de um repositório do GitHub para começar!

## Funcionalidades

- Pesquisa de repositórios por nome usando a API do GitHub
- Adição de repositórios por URL
- Marcar/desmarcar repositórios como favoritos
- Listar todos os repositórios adicionados
- Persistência local (em breve com autenticação)
- Paginação de resultados
- Interface amigável com React + TypeScript

## Como executar

### Frontend (React + Vite + TypeScript)

```bash
# Instalar dependências
cd frontend
npm install

# Arquivo .env
cp .env.example .env

# edite o .env com a URL da sua API, por exemplo:
VITE_API_URL=https://localhost:7174

# Iniciar servidor de desenvolvimento
npm run dev
```

### Backend (ASP.NET Core)

```bash
cd backend/MyRepos.Api
dotnet run
```

## Tecnologias

### Frontend:

- React
- TypeScript
- React Router
- Vite
- Context API

### Backend:

- ASP.NET Core
- Entity Framework InMemory
- Mapster
- MediatR
- CORS habilitado

## Funcionalidades futuras

- Autenticação e cadastro
- Salvamento persistente de dados
- Mostrar README na página de detalhes
- Mostar contribuidores
- Autenticação API GitHub
- Ao carregar, atualizar infos de repositórios salvos
