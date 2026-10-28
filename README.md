# FinShark

A back-end refresher project using ASP.NET 8 with Entity Framework: a simple REST API for stocks and comments, with a React frontend.

## About The Project

A containerized full-stack project centered on an ASP.NET 8 REST API (stocks and comments) backed by SQL Server through Entity Framework Core, plus a React frontend.

### Built With

- ASP.NET 8 + Entity Framework Core (API)
- SQL Server (database)
- React (frontend, in `frontend/`)
- Docker Compose

## Getting Started

### Prerequisites

- Docker and Docker Compose

### Installation

Build and launch the stack (API, SQL Server database, frontend):

```sh
docker compose -f compose.development.yml up --build
```

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

## License

No license file is present in this repository.

## Contact

Dyrits - https://github.com/Dyrits
