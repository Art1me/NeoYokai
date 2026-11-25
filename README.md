# Neo-Yokai

Cyberpunk 2D Action-RPG combining a **Unity 6 (C#, 2D URP)** client with a **Java / Spring Boot** backend, **PostgreSQL** persistence, and **Docker** local infrastructure.

## Architecture & Repository Layout

```text
NeoYokai/
├── Client/   # Unity 6 (6000.0.84f1) 2D URP game client (C#)
├── Server/   # Spring Boot backend (Spring Data JPA, WebMVC, Maven)
├── Docker/   # Docker Compose setup for PostgreSQL 16
└── Docs/     # Game design specs, technical architecture, and MVP Kanban
```

## Tech Stack

- **Game Client:** Unity `6000.0.84f1` (C#, 2D URP)
- **Backend:** Java (`17`/`21`), Spring Boot `4.1.1`, Spring Data JPA, Spring WebMVC, Maven Wrapper
- **Database:** PostgreSQL `16` (`postgres:16-alpine`)
- **CI:** GitHub Actions ([backend-check.yml](.github/workflows/backend-check.yml))

## Quick Start

### 1. Start PostgreSQL
```bash
cd Docker
docker compose up -d
```

### 2. Build & Run Backend
```bash
cd Server
./mvnw spring-boot:run
```

On Windows PowerShell:
```powershell
cd Server
.\mvnw.cmd spring-boot:run
```

### 3. Open Client
Open `Client/` in **Unity Hub** using Unity `6000.0.84f1`.

## License

[MIT](LICENSE)
