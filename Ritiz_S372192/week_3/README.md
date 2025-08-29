# Theater Admin API

A .NET Core Web API project for managing theater movies and categories with a jQuery client interface.

## Features

- **Movie Management**: Create, read, update, and delete movies
- **Category Management**: Create, read, update, and delete categories
- **Validation**: Server-side validation using data annotations
- **Database**: SQLite database with Entity Framework Core
- **Client Interface**: jQuery-based web interface with Bootstrap styling

## Movie Entity

- **Id**: Primary key
- **Name**: Movie title (required, max 200 characters)
- **Release Date**: Movie release date (required)
- **Director**: Movie director (required, max 150 characters)
- **Contact Email Address**: Contact email (required, email validation)
- **Language**: Enum (English, Japanese, Chinese)
- **Category**: Foreign key relationship to Category (required)

## Category Entity

- **Id**: Primary key
- **Name**: Category name (required, max 100 characters)
- **Code**: Category code (required, max 10 characters, unique)

## Technology Stack

- **Backend**: ASP.NET Core 9.0 Web API
- **Database**: SQLite with Entity Framework Core
- **Frontend**: HTML5, CSS3, jQuery, Bootstrap 5
- **Validation**: Data Annotations
- **Architecture**: Code-First approach

## API Endpoints

### Categories
- `GET /api/Categories` - Get all categories
- `GET /api/Categories/{id}` - Get category by ID
- `POST /api/Categories` - Create new category
- `PUT /api/Categories/{id}` - Update category
- `DELETE /api/Categories/{id}` - Delete category

### Movies
- `GET /api/Movies` - Get all movies (includes category data)
- `GET /api/Movies/{id}` - Get movie by ID (includes category data)
- `POST /api/Movies` - Create new movie
- `PUT /api/Movies/{id}` - Update movie
- `DELETE /api/Movies/{id}` - Delete movie

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- Git

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd TheaterAdminAPI
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

5. Open your browser and navigate to:
```
https://localhost:7001
```

## Usage

### Web Interface
- Navigate to the root URL to access the jQuery client interface
- Use the tabs to switch between Categories and Movies management
- Add, edit, and delete records using the forms and tables

### API Testing
- Use tools like Postman or curl to test the API endpoints directly
- The API returns JSON responses
- All endpoints support standard HTTP methods
