# template-dotnet-spa-react

A full-stack starter template combining a .NET 10 REST API with a React SPA frontend. The backend (C#) serves a simple CRUD API for managing animals, while the frontend (React + Vite + TypeScript) uses Tailwind CSS and shadcn/ui components. Both live in a monorepo under `packages/api` and `packages/web`, managed by Bun workspaces.

Built as a starting point for the AI Masterclass — participants wire the frontend to the backend and build out features from there.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Bun](https://bun.sh/) (v1.3+)

## Quick start

**Frontend:**

```bash
# install dependencies
bun install

# start the frontend
bun run dev

# generate the API types
bun run gen:api  
```

**Backend:**

```bash
# run the API Service in watch mode
bun run dev:api

# run the API unit tests
bun run test:api
bun run test:api:int
```
