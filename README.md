# LottoManagerAPI

> Rest API for managing lotteries. This project is made for study and practice only.

---

## 📌 Sumário

- [Overview](#-overview)
- [Architecture and Concepts](#-architecture-and-concepts)
- [Tech Stack](#-tech-stack)
- [Prerequisites](#-prerequisites)
- [Setup](#-setup)
- [Run the Project](#-run-the-project)
- [Environments](#-environments)
- [Structure](#-structure)
- [Tests](#-tests)
- [Authentication](#-authentication)
- [Docs](#-docs)
- [Endpoints](#-endpoints)
- [Logs and Monitoring](#-logs-and-monitoring)

---

## 📖 Overview

This API is a study-and-practice project, with a simple goal: review and expand important concepts.
- It was made mainly for backend lovers and data structures and algorithms enthusiasts!
- This API goes beyond simple CRUD: it deals with huge amounts of data, processing them in an efficient way.
- A use case could be: how to process millions of bets and generate a report with the winners.

---

## 🏗️ Architecture and Concepts

- API REST
- Clean Architecture and layer separation
- .NET Minimal APIs (no controllers)

---

## 🛠️ Tech Stack

- C# with .NET Core 10
- PostgreSQL database
- PGAdmin for database management and display
- Entity Framework Core
- xUnit for tests
- Docker for local DB
- FluentValidation
- *Auth: to be added*
- *Logs: to be added*

---

## ⚙️ Prerequisites

You need to install the following tools:
- .NET Core 10 SDK
- Docker

---

## 🔧 Setup

In order to properly run the database container, an `.env` file is required at the root folder that contains the solution. Follow this example:

```
POSTGRES_USER=admin
POSTGRES_PASSWORD=strong_password_here
POSTGRES_DB=lottomanager
PGADMIN_DEFAULT_EMAIL=admin@lottomanager.com
PGADMIN_DEFAULT_PASSWORD=another_strong_password
POSTGRES_PORT=5432
PGADMIN_PORT=8080
```

All variables starting with `POSTGRES` refer to the database itself. All the `PGADMIN` variables are for

---

## ▶️ Run the Project

To have a local database to work with, activate the Docker containers by running the following terminal command at the solution folder:
```bash
docker compose up -d
```

After cloning the repository to a local folder, open the solution (LottoManager.slnx) with an IDE of your choice. We recommend Visual Studio 2026, JetBrains Rider or VS Code.

To run with Visual Studio, select the proper project (LottoManager.Api) and click this button:

<img width="256" height="40" alt="image" src="https://github.com/user-attachments/assets/a97bf5ec-f61a-4492-afe0-d3baf918dd51" />

To run with VS Code or with just a terminal, use the `dotnet` CLI: open the project folder and run the command:
```bash
dotnet run
```

The HTTP version should start at the port `5095`. The HTTPS version should be available at port `7273`, as prescribed in `Properties/launchSettings.json` file of the API Project.

---

## 🌍 Environments

*Soon.*

---

## 🗂️ Structure

The project follows Clean Architecture and is composed by these projects:
- src/Domain: entities, interfaces, and enums.
- src/Contracts: defines requests and responses.
- src/Application: business logic.
- src/Infrastructure: database communication and gateways.
- src/Api: ASP.NET Web Api project.
- tests/UnitTests: xUnit project for unit tests.

---

## 🧪 Tests

To run the unit tests using the CLI, just run `dotnet test` in the solution folder.

If using an IDE like Visual Studio, right-click in the Tests project and click Run.

---

## 🔐 Authentication

*Soon.*

---

## 📑 Docs

*Soon.*

---

## 🔗 Endpoints

*Soon.*

---

## 📊 Logs e Monitoring

*Soon.*

---

This project (and also this ReadMe) is under construction.
