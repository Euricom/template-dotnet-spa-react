# template-dotnet-spa

A full-stack starter template combining a .NET 10 REST API with SPA frontends in React and Angular. The backend (C#) serves a simple CRUD API for managing animals, while two frontend options are provided:

- **React** (`packages/web-react`) — React + Vite + TypeScript with Tailwind CSS and shadcn/ui components
- **Angular** (`packages/web-ng`) — Angular + Vite + TypeScript with Tailwind CSS

Both frontends and the API live in a monorepo managed by Bun workspaces.

Built as a starting point for the AI Masterclass — participants wire a frontend to the backend and build out features from there.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Bun](https://bun.sh/) (v1.3+)

## Quick start

**Frontend (React):**

```bash
# install dependencies
bun install

# start the React frontend
bun run --filter web-react dev

# generate the API types
bun run gen:api  
```

**Frontend (Angular):**

```bash
# start the Angular frontend
bun run --filter web-ng dev
```

**Backend:**

```bash
# run the API Service in watch mode
bun run dev:api

# run the API unit tests
bun run test:api
bun run test:api:int
```
