# Movie Theatre Admin (Web API + jQuery)

Admin web app for theatre staff to manage Categories and Movies. Backend is ASP.NET Core Web API (net9.0) with EF Core + SQLite; frontend is static jQuery pages served from wwwroot.

## Prerequisites
- .NET SDK 9

## Quick start
```bash
# from repo root
cd "movieTheatre/movieTheatre"

# build
dotnet build

# (first time) install EF CLI if not installed yet
export PATH="$PATH:/Users/$USER/.dotnet/tools"
dotnet tool install --global dotnet-ef

# ensure database exists and is up to date
Dotnet ef database update

# run (option A) using dev profile (http://localhost:5120)
dotnet run --launch-profile http

# run (option B) choose your own port (e.g., 5288)
dotnet run --urls http://localhost:5288
```

Access:
- Admin index: http://localhost:5120/admin/ (or your custom port)
- Categories UI: http://localhost:5120/admin/categories.html
- Movies UI: http://localhost:5120/admin/movies.html
- API docs (Development only): http://localhost:5120/swagger

Seed data (on first run):
- Categories: Action (ACT), Drama (DRM), Horror (HOR)

## API endpoints
- Categories
  - GET `/api/categories`
  - GET `/api/categories/{id}`
  - POST `/api/categories`  body:
    ```json
    { "name": "Comedy", "code": "COM" }
    ```
  - PUT `/api/categories/{id}` body:
    ```json
    { "id": 1, "name": "Action", "code": "ACT" }
    ```
  - DELETE `/api/categories/{id}`

- Movies
  - GET `/api/movies`
  - GET `/api/movies/{id}`
  - POST `/api/movies` body:
    ```json
    {
      "name": "Inception",
      "releaseDate": "2010-07-16",
      "director": "Christopher Nolan",
      "contactEmail": "info@inception.com",
      "language": "English",
      "categoryId": 1
    }
    ```
  - PUT `/api/movies/{id}` body:
    ```json
    {
      "id": 1,
      "name": "Inception (Edited)",
      "releaseDate": "2010-07-16",
      "director": "Christopher Nolan",
      "contactEmail": "contact@inception.com",
      "language": "English",
      "categoryId": 1
    }
    ```
  - DELETE `/api/movies/{id}`

Notes:
- `language` is an enum: `English`, `Japanese`, `Chinese` (serialized as strings in JSON)
- `categoryId` is required (NOT NULL)
- Validation returns RFC7807 ProblemDetails with field errors when applicable

## Admin UI (jQuery)
- Served from `wwwroot/admin`:
  - `/admin/index.html`, `/admin/categories.html`, `/admin/movies.html`
- Provides CRUD via AJAX; forms mirror server validation and show inline errors

## Working with the database (EF Core)
```bash
# create a new migration after model changes
dotnet ef migrations add <Name> -o Migrations

# apply migrations
dotnet ef database update
```
- SQLite file path: `movieTheatre/movieTheatre/movieTheatre.db`

## Development tips
- Live reload:
  ```bash
  dotnet watch run --project movieTheatre.csproj --urls http://localhost:5288
  ```
- To see Swagger UI when not using launch profiles, set environment explicitly:
  ```bash
  ASPNETCORE_ENVIRONMENT=Development dotnet run --urls http://localhost:5288
  ```

## Troubleshooting
- Address already in use (e.g., port 5120):
  - Run on another port: `dotnet run --urls http://localhost:5288`
  - Or stop the other process using the port (macOS):
    ```bash
    lsof -i :5120
    kill -9 <PID>
    ```
- `dotnet-ef` not found:
  - Install and/or add to PATH:
    ```bash
    export PATH="$PATH:/Users/$USER/.dotnet/tools"
    dotnet tool install --global dotnet-ef
    ```
- HTTPS redirect warning in logs:
  - Either run with both HTTP/HTTPS URLs (e.g., `--urls https://localhost:7231;http://localhost:5120`) or ignore for local HTTP-only runs.

## Sample requests
- Use the included HTTP file: `movieTheatre/movieTheatre/movieTheatre.http`
- Or curl, e.g.:
  ```bash
  curl http://localhost:5120/api/categories
  ```
