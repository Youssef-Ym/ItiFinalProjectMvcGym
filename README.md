# Gym Management System

An ASP.NET Core MVC application for managing gym operations, including members, trainers, classes, schedules, and class enrollment. Developed as an ITI software engineering project, it applies layered design and separates presentation, business logic, and data access responsibilities.

## Features

- Manage members, trainers, and gym classes
- Assign trainers to classes and manage schedules
- Enroll members in classes
- View enrolled members
- Filter classes dynamically by trainer
- Role-based access for administrative and trainer workflows

## Technology

- C# and ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap 5, HTML, CSS, and JavaScript
- AJAX for dynamic filtering

## Architecture

The application separates its main responsibilities into presentation, application/business logic, data access, and domain layers. Repository abstractions organize data access.

## Getting Started

### Prerequisites

- .NET SDK compatible with the solution
- SQL Server or SQL Server LocalDB
- Entity Framework Core CLI tools

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/Youssef-Ym/ItiFinalProjectMvcGym.git
   cd ItiFinalProjectMvcGym
   ```

2. Configure the database connection for your local SQL Server using local configuration. Keep secrets out of committed files.

3. Apply the database migrations and run the application:

   ```bash
   dotnet ef database update
   dotnet run
   ```

If the solution contains multiple projects, run these commands from the web application project directory.

## Security Note

No test account credentials are published here. Configure development accounts locally and use unique credentials.

## Project Context

Built as part of the ITI (Information Technology Institute) software engineering curriculum.

## Author

Youssef Mohamed Abdelsalam · [GitHub](https://github.com/Youssef-Ym)
