# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files to leverage Docker layer caching
COPY ["PokemonGO.sln", "."]
COPY ["PokemonGO_Backend.API/PokemonGO_Backend.API.csproj", "PokemonGO_Backend.API/"]
COPY ["PokemonGO_Backend.Application/PokemonGO_Backend.Application.csproj", "PokemonGO_Backend.Application/"]
COPY ["PokemonGO_Backend.Contract/PokemonGO_Backend.Contract.csproj", "PokemonGO_Backend.Contract/"]
COPY ["PokemonGO_Backend.Domain/PokemonGO_Backend.Domain.csproj", "PokemonGO_Backend.Domain/"]
COPY ["PokemonGO_Backend.Infrastructure/PokemonGO_Backend.Infrastructure.csproj", "PokemonGO_Backend.Infrastructure/"]
COPY ["PokemonGO_Backend.Persistance/PokemonGO_Backend.Persistance.csproj", "PokemonGO_Backend.Persistance/"]

# Restore dependencies
RUN dotnet restore "PokemonGO.sln"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/PokemonGO_Backend.API"
RUN dotnet build "PokemonGO_Backend.API.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "PokemonGO_Backend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the port the app runs on (check your app's configuration, 80 and 443 are common defaults)
# Render.com automatically handles port detection for web services, but this is good practice.
EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "PokemonGO_Backend.API.dll"]
