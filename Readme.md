
# PokemonGO Clone

This project is a clone of the popular augmented reality game PokemonGO. It includes a .NET backend and a Unity 3D frontend.

## About The Project

This project is a recreation of the core functionalities of PokemonGO. It allows users to catch pokemons, battle with other trainers, and conquer gyms.

### Backend

The backend is built with .NET and follows a clean architecture pattern. It uses a layered architecture with the following projects:

*   **PokemonGO_Backend.API**: The presentation layer, responsible for handling HTTP requests and responses.
*   **PokemonGO_Backend.Application**: The application layer, containing the business logic of the application.
*   **PokemonGO_Backend.Contract**: The contract layer, defining the data transfer objects (DTOs) and service interfaces.
*   **PokemonGO_Backend.Domain**: The domain layer, containing the core entities of the application.
*   **PokemonGO_Backend.Infrastructure**: The infrastructure layer, responsible for external services like logging and email.
*   **PokemonGO_Backend.Persistance**: The persistence layer, responsible for data access and communication with the database.

### Getting Started

To get a local copy up and running follow these simple steps.

#### Prerequisites

*   .NET 8
*   SQL Server
*   Unity 3D

#### Installation

1.  Clone the repo
    ```sh
    git clone https://github.com/sanandev05/PokemonGO_Backend.git
    ```
2.  Open the solution in Visual Studio
3.  Update the connection string in `appsettings.json`
4.  Run the database migrations
    ```sh
    dotnet ef database update
    ```
5.  Run the backend
    ```sh
    dotnet run --project PokemonGO_Backend.API
    ```

### API Endpoints

The following are the available API endpoints:

*   **Badge**: `GET /api/Badge`, `GET /api/Badge/{id}`, `POST /api/Badge`, `PUT /api/Badge/{id}`, `DELETE /api/Badge/{id}`
*   **Gym**: `GET /api/Gym`, `GET /api/Gym/{id}`, `POST /api/Gym`, `PUT /api/Gym/{id}`, `DELETE /api/Gym/{id}`
*   **Location**: `GET /api/Location`, `GET /api/Location/{id}`, `POST /api/Location`, `PUT /api/Location/{id}`, `DELETE /api/Location/{id}`
*   **PokemonAbility**: `GET /api/PokemonAbility`, `GET /api/PokemonAbility/{id}`, `POST /api/PokemonAbility`, `PUT /api/PokemonAbility/{id}`, `DELETE /api/PokemonAbility/{id}`
*   **PokemonCategories**: `GET /api/PokemonCategories`, `GET /api/PokemonCategories/{id}`, `POST /api/PokemonCategories`, `PUT /api/PokemonCategories/{id}`, `DELETE /api/PokemonCategories/{id}`
*   **Pokemon**: `GET /api/Pokemon`, `GET /api/Pokemon/{id}`, `POST /api/Pokemon`, `PUT /api/Pokemon/{id}`, `DELETE /api/Pokemon/{id}`
*   **Tournament**: `GET /api/Tournament`, `GET /api/Tournament/{id}`, `POST /api/Tournament`, `PUT /api/Tournament/{id}`, `DELETE /api/Tournament/{id}`
*   **Trainer**: `GET /api/Trainer`, `GET /api/Trainer/{id}`, `POST /api/Trainer`, `PUT /api/Trainer/{id}`, `DELETE /api/Trainer/{id}`

### Frontend

The frontend is built with Unity 3D. You can find the frontend repository here: [https://github.com/sanandev05/PokemonGO_Frontend](https://github.com/sanandev05/PokemonGO_Frontend)

### Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

### License

Distributed under the MIT License. See `LICENSE` for more information.
