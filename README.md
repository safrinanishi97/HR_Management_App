# HRM Management System (Clean Architecture)

A full-featured Human Resource Management(HRM) system implemented using **Clean Architecture** principles with .NET 9 Web API backend and Angular frontend.

---

## Project Architecture

### Backend (.NET 9 Web API)

- **Clean Architecture Layers**:

  - **Presentation Layer**: API Controllers (Handles HTTP requests/responses)
  - **Application Layer**: CQRS/MediatR (Business rules, use cases, DTOs, validation)
  - **Domain Layer**: Core business entities and interfaces (pure business logic, no external dependencies)
  - **Infrastructure Layer**: EF Core, DB Context, Repository implementations, external integrations

- **Technology Stack**:
  - ASP.NET Core 9 Web API
  - Entity Framework Core (Database-First)
  - SQL Server
  - MediatR (Command/Query separation)
  - Manual Mapping
  - Dependency Injection
  - FluentValidation

---

## Key Features (Backend)

- Employee CRUD with Master-Detail Support
- Clean DTO <=> Entity mapping (Separation of Concerns)
- Repository & Unit of Work patterns
- Image Upload (e.g., Employee photo)
- File Upload (e.g., Employee document)
- Lookup APIs for dropdown population (Department, Designation, Gender, etc.)
- Fully decoupled layers for maintainability and testability

---

## Planned Features (To Be Implemented)

- JWT Authentication & Role-based Authorization
- Pagination and Filtering for list endpoints
- Angular + Kendo UI frontend with dynamic dropdown binding

---

## Project Structure

```plaintext
HRMApp.sln
│
├── Presentation ├── HRMApp.API # Presentation Layer
│             
├── Core
│     │
│     ├── HRMApp.Application   # Application Layer (CQRS, DTOs, Interfaces)
│     ├── HRMApp.Domain        # Domain Layer (Entities, Enums, Core Interfaces)
│     
└──  Infrastructure
      │
      ├── HRMApp.Infrastructure # Infrastructure Layer (Email, SMS, Logging, Third Part API(Payment, Getway, Cloud Storage))
      ├── HRMApp.Persistence    # Infrastructure Layer (EF Core, DB Context, Repository Implementations)
      


---

## Getting Started

### Prerequisites

- [.NET SDK 9 Preview](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Visual Studio 2022 / VS Code
- SQL Server
- Angular CLI

### Clone the Repository

```bash
git clone https://github.com/safrinanishi97/HR_Management_App.git
```

### Contributing

Feel free to fork and raise pull requests. If you find bugs, open an issue with detailed explanation.

