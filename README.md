# FinShark

A back-end refresher project using ASP.NET 8 with Entity Framework: a simple REST API for stocks and comments, with a React frontend.

**Status: abandoned - development stopped before the project was finished.**

## About The Project

A containerized full-stack project centered on an ASP.NET 8 REST API (stocks and comments) backed by SQL Server through Entity Framework Core, plus a React frontend.

### Built With

- ASP.NET 8 + Entity Framework Core (API)
- SQL Server (database)
- React + Vite (frontend, in `frontend/`)
- Docker Compose

## Getting Started

### Prerequisites

- Docker and Docker Compose

### Installation

Build and launch the stack (API, SQL Server database, frontend):

```sh
docker compose -f compose.development.yml up --build
```

Copy `.env.example` to `.env` at the repository root and set `DB_PASSWORD` (the local SQL Server password; compose refuses to start without it).

The frontend needs a Financial Modeling Prep API key: copy `frontend/.env.example` to `frontend/.env` and set `VITE_API_KEY`.

Entity Framework commands can be run against the containerized API:

```sh
make ef <command>   # e.g. make ef migrations list
```

## Project structure

| Path | Role |
| --- | --- |
| `api/` | ASP.NET 8 API (controllers, DTOs, EF Core data, services) |
| `frontend/` | React client |
| `compose.development.yml` | api, database (SQL Server) and frontend services |

## Known limits (archived, October 2026)

This repository is archived and read-only. Last maintenance update, October 2026:

- Dependencies updated within supported ranges (ASP.NET Core / EF Core 8.0.33; frontend moved from Create React App to Vite).
- Frontend `npm audit`: 3 moderate findings remain (react-router open redirect, fixed only in v7, a major upgrade not done; uuid 9, not reachable by this app).
- The only frontend test (`App.test.tsx`) is the unmodified starter test and fails, because the component needs a router.
- Not run end to end: the full Docker Compose stack and logged-in API calls were not exercised after the update.
- A SQL Server `sa` password for the local Docker database was also committed in early history and was in the configuration files until this update. Treat it as exposed and do not reuse it.
- An API key was committed to early history of this repository. It was removed from the current files but remains in git history, so treat it as exposed.

## License

No license file is present in this repository.

## Contact

Dyrits - https://github.com/Dyrits
