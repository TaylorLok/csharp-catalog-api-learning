# csharp-catalog-api-learning

🎓 **Learning C# and ASP.NET Core Web API Development**

A catalog service API built while learning C#, ASP.NET Core, and MongoDB integration. This project demonstrates modern web API development practices and serves as a learning foundation for microservices architecture.

---

## 🚀 What This Project Demonstrates

- **RESTful API development** with ASP.NET Core
- **MongoDB integration** with proper serialization
- **Swagger/OpenAPI documentation** for interactive API testing
- **CRUD operations** with proper HTTP status codes
- **Entity-DTO mapping patterns** for clean architecture
- **Docker containerization basics**
- **Microservices architecture patterns**

---

## 🛠️ Tech Stack

- **C#** - Primary programming language
- **ASP.NET Core** - Web API framework
- **MongoDB** - NoSQL database
- **Swagger/OpenAPI** - API documentation
- **Docker** - Containerization

---

## 📋 Features

### Current Implementation

- ✅ Get all catalog items
- ✅ Get item by ID
- ✅ Create new items
- ✅ Update existing items
- ✅ Delete items
- ✅ Interactive Swagger UI
- ✅ MongoDB persistence
- ✅ Proper error handling

---

## 📚 API Endpoints

| **Method** | **Endpoint**      | **Description**                  |
|------------|-------------------|----------------------------------|
| `GET`      | `/items`          | Retrieve all catalog items       |
| `GET`      | `/items/{id}`     | Retrieve a specific item by ID   |
| `POST`     | `/items`          | Create a new catalog item        |
| `PUT`      | `/items/{id}`     | Update an existing item          |
| `DELETE`   | `/items/{id}`     | Delete an item                   |

---

## 🏃‍♂️ Getting Started

### Prerequisites

- **.NET 9 SDK**
- **MongoDB** (local installation or Docker)
- **Visual Studio 2022** or **VS Code**

### Running the Application

1. **Clone the repository**
    ```bash
    git clone https://github.com/yourusername/csharp-catalog-api-learning.git
    cd csharp-catalog-api-learning
    ```

2. **Start MongoDB** (if using Docker)
    ```bash
    docker run -d -p 27017:27017 --name mongodb mongo:latest
    ```

3. **Run the application**
    ```bash
    dotnet run
    ```

4. **Access Swagger UI**
    ```
    https://localhost:5001/swagger
    ```

Run the application
bashdotnet run

Access Swagger UI
https://localhost:5001/swagger
