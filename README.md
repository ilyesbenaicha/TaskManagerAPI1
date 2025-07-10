# 🧩 TaskManagerAPI

A simple .NET 8 Web API for managing users and tasks with role-based access control (RBAC). Built with Entity Framework Core (In-Memory), clean architecture, and Swagger documentation.

---

## 🚀 Features

- ✅ CRUD operations for Users and Tasks
- 🔐 Role-based access control (Admin/User)
- 🧠 Middleware for user context injection
- 🗂️ Clean architecture with services and repositories
- 🧪 Unit tests using xUnit and Moq
- 📘 Swagger/OpenAPI documentation
- 🧬 In-memory database with seeded data

---

## 🛠️ Technologies

- .NET 8
- Entity Framework Core (InMemory)
- xUnit + Moq
- Swagger (Swashbuckle)
- Dependency Injection
- RESTful API

---

## 📦 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code

---

## 📁 Project Structure
TaskManagerAPI/ 
├── Controllers/ 
├── Data/ 
├── Middleware/ 
├── Models/ 
├── Repositories/ 
├── Services/ 
├── Tests/ 
└── Program.cs



---

## 🧪 Seeded Data

| User Type | ID | Username | Role  |
|-----------|----|----------|-------|
| Admin     | 1  | admin    | Admin |
| User      | 2  | user     | User  |

| Task ID | Title   | Assigned To |
|---------|---------|-------------|
| 1       | Task 1  | Admin       |
| 2       | Task 2  | User        |
| 3       | Task 3  | User        |

Use the `X-User-Id` header to simulate authentication.

---

## 🧰 How to Build and Run

### 🔧 Build the Project

```bash
dotnet build

dotnet run

The API will be available at:
https://localhost:5001
http://localhost:5000
