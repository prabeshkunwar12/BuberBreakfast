# Buber Breakfast

Buber Breakfast is a tutorial project built using .NET 6 to create a REST API. It aims to demonstrate best practices in building APIs, employing technologies such as ASP.NET 6 and dotnet CLI. The project follows principles of functional programming and domain-driven design.

## Backend Service Architecture

The application consists of two main projects:

1. **BuberBreakfast.Contracts**: This project contains the definitions of the API, serving as the contract between the client and the server.
2. **BuberBreakfast**: This project contains the actual logic of the application, implementing the functionality defined in the contracts.

### Why Split into 2 Projects?

Splitting the application into two projects offers several benefits:

- **Modularity**: By separating the contract definitions from the implementation, we can maintain a clear separation of concerns.
- **Reusability**: Defining the API as a class library allows us to publish it as a NuGet package. Clients written in .NET can then easily consume the package without having to reimplement the API themselves.
- **Versioning**: Using NuGet packages facilitates versioning. As the API evolves and new versions are introduced, we can simply publish new packages, ensuring smooth upgrades for clients.

## Technologies

- **ASP.NET 8**: The framework for building APIs and web applications.
- **dotnet CLI**: The command-line interface for managing .NET projects and solutions.

## Architecture Choices

- **CRUD REST API**: Following the principles of Representational State Transfer (REST) for creating, reading, updating, and deleting resources.
- **Best Practices**: Adhering to industry best practices in software development, including proper documentation, testing, and code organization.
- **Functional Programming**: Embracing functional programming paradigms to write clean, concise, and maintainable code.
- **Domain-driven Design**: Organizing code around business domain concepts to ensure alignment with the problem domain.

## Tutorial Source

The project is based on tutorials from the following sources:

- **Free Code Camp**: Provides free tutorials and resources for learning web development and software engineering.
- **Amichai Mantinband, Engineer @Microsoft**: Offers insights and guidance on building applications using Microsoft technologies.

## Getting Started

To start working on the project, follow these steps:

1. Create a new solution:
   ```bash
   dotnet new sln -o BuberBreakfast
   ```

2. Define the API contract:
   ```bash
   dotnet new classlib -o BuberBreakfast.Contracts
   ```

3. Implement the application logic:
   ```bash
   dotnet new webapi -o BuberBreakfast
   ```

4. Add the projects to the solution:
   ```bash
   dotnet sln add ./BuberBreakfast.Contracts ./BuberBreakfast
   ```
   or
   ```bash
   dotnet sln add $(ls -r **/*.csproj)
   ```

5. Add the reference of contract project to main project:
   ```bash
   dotnet add ./BuberBreakfast/ reference ./BuberBreakfast.Contracts/
   ```

5. Run the project:
   ```bash
   dotnet run --project ./BuberBreakfast/
   ```

These steps will set up the solution and projects, allowing you to start developing your REST API.

