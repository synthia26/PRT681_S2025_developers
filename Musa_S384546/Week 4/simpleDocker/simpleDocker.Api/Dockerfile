# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ./simpleDocker.Api/simpleDocker.Api.csproj ./simpleDocker.Api/
RUN dotnet restore ./simpleDocker.Api/simpleDocker.Api.csproj

# Copy everything and build
COPY ./simpleDocker.Api ./simpleDocker.Api
WORKDIR /src/simpleDocker.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8443
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "simpleDocker.Api.dll"]


