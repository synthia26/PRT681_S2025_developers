# Movie Theatre Admin (Web API + jQuery)

Run, test, and admin UI for managing Categories and Movies.

## Prereqs
- .NET SDK 9

## Install & Database
```
cd "movieTheatre/movieTheatre"
dotnet build
# first time only
export PATH="$PATH:/Users/$USER/.dotnet/tools"
dotnet tool install --global dotnet-ef
# apply migrations if needed
 dotnet ef database update
```

## Run
- Default profile uses 5120. If in use, run on another port:
```
dotnet run --project movieTheatre.csproj --urls http://localhost:5288
```

## API docs
- Swagger UI (Development): http://localhost:5288/swagger

## Admin UI
- Index: http://localhost:5288/admin/
- Categories: http://localhost:5288/admin/categories.html
- Movies: http://localhost:5288/admin/movies.html

## Sample requests
See `movieTheatre/movieTheatre/movieTheatre.http` for ready-made requests.

## Notes
- SQLite file: `movieTheatre/movieTheatre/movieTheatre.db`
- Seeded categories: Action (ACT), Drama (DRM), Horror (HOR)
- Validation: server-side (DataAnnotations) + client-side for forms
