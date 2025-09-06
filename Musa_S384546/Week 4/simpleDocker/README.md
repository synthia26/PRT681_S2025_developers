simpleDocker

Blazor (Razor Components) app with a .NET 9 minimal Web API and Microsoft SQL Server, containerized with Docker Compose.

Prerequisites
- Docker Desktop (recommended latest)
- Optional for local dev without Docker: .NET SDK 9.0+

Project structure
- `simpleDocker/` – Blazor UI (server-side interactivity)
- `simpleDocker.Api/` – .NET 9 minimal API with Swagger and `/health`
- `docker-compose.yml` – Orchestrates API (`api`) and SQL Server (`db`)

Quick start (Docker)
1) Optional: set a strong SA password (else default is used)
   - macOS/Linux:
     ```bash
     export SA_PASSWORD='YourStrong!Passw0rd'
     ```
   - Windows PowerShell:
     ```powershell
     $env:SA_PASSWORD='YourStrong!Passw0rd'
     ```

2) Build and start containers from the repository root:
   ```bash
   docker compose up -d --build
   ```

3) Verify API is running:
   ```bash
   curl http://localhost:5080/health
   # -> {"status":"Healthy"}
   ```

4) Open Swagger UI:
   - http://localhost:5080/swagger

5) SQL Server connection
   - Host (from your machine): `localhost,15433`
   - Host (from containers): `db,1433`
   - Credentials: `sa` / `${SA_PASSWORD}` (or the default `YourStrong!Passw0rd` if not set)
   - Example connection strings:
     - ADO.NET (host): `Server=localhost,15433;Database=SimpleDb;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True;`
     - From another container: `Server=db,1433;Database=SimpleDb;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True;`

6) Stop and clean up:
   ```bash
   docker compose down
   # Remove data volume (DANGEROUS: deletes DB data)
   docker volume rm simpledocker_mssqldata
   ```

Dev workflows (without Docker)
- Run API locally:
  ```bash
  cd simpleDocker.Api
  dotnet run
  ```
  Launch settings expose:
  - HTTP: http://localhost:5080
  - HTTPS: https://localhost:7080

- Run Blazor app locally:
  ```bash
  cd simpleDocker
  dotnet run
  ```
  Launch settings expose:
  - HTTP: http://localhost:5151
  - HTTPS: https://localhost:7127

Ports (Docker Compose)
- API: host `5080` -> container `8080`
- SQL Server: host `15433` -> container `1433`

If these host ports conflict on your machine, edit `docker-compose.yml`:
```yaml
services:
  api:
    ports:
      - "<HOST_PORT>:8080"
  db:
    ports:
      - "<HOST_PORT>:1433"
```

Troubleshooting
- Check logs:
  ```bash
  docker compose logs -f api
  docker compose logs -f db
  ```
- Rebuild API image after changes:
  ```bash
  docker compose build api --no-cache
  ```
- Verify containers and port mappings:
  ```bash
  docker ps --format 'table {{.Names}}\t{{.Ports}}'
  ```
- Apple Silicon (ARM64) note for SQL Server:
  - You may see a platform warning; it still runs under emulation. If needed, pin platform:
    ```yaml
    services:
      db:
        platform: linux/amd64
    ```

Notes
- The API currently doesn’t use the database; the connection string is provided via environment variable `ConnectionStrings__Default` for future use (EF Core or ADO.NET).
- Always use a strong `SA_PASSWORD` in non-development environments; never commit secrets.


