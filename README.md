# Blog API Project

The **Blog API** is a comprehensive RESTful API for blog management, built using **.NET** and following **Clean Architecture** principles. The system provides robust Authentication, Post management, and Comment management features with role-based authorization (Admin and User).

## 🏗️ Architecture

The project follows **Clean Architecture** to ensure separation of concerns and scalability:

* **Blog.Core**: The core layer containing domain Entities (e.g., `Post`, `Comment`, `ApplicationUser`) and Interfaces.
* **Blog.Application**: Contains business logic, Services (`PostService`, `CommentService`, `AuthService`), DTOs, and AutoMapper configurations.
* **Blog.Infrastructure**: Responsible for database interactions (EF Core), Identity implementation, and Repositories (`PostRepo`, `CommentRepo`).
* **Blog.Api**: The presentation layer containing Controllers and the application entry point (`Program.cs`).

## 🚀 Tech Stack

* **Framework**: .NET (Target Framework: `net10.0` as specified in project files).
* **Database**: PostgreSQL (using Npgsql).
* **ORM**: Entity Framework Core.
* **Authentication**: ASP.NET Core Identity + JWT (JSON Web Tokens).
* **Mapping**: AutoMapper.
* **Validation**: FluentValidation.
* **API Documentation**: Scalar.

## 🌟 Key Features

### 1. Authentication & Security
* User Registration (`Register`).
* Login to obtain Access Token and Refresh Token.
* Token renewal using Refresh Token.
* Role-Based Authorization: `Admin` and `User`.

### 2. Post Management
* Create, Update, and Delete posts.
* Retrieve all posts or posts specific to the logged-in user.
* Protection rules: Posts can only be modified or deleted by the owner or an Admin.

### 3. Comment Management
* Add comments to posts.
* Update and Delete comments (Owner/Admin restricted).

## ⚙️ Setup & Installation

### Prerequisites
* .NET SDK.
* PostgreSQL Server.

### Installation Steps

1.  **Clone the Repository:**
    ```bash
    git clone <repository-url>
    ```

2.  **Configure `appsettings.json`:**
    Update the `appsettings.json` (or `appsettings.Development.json`) in the `Blog.Api` project with your database connection string and JWT settings.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=BlogDb;Username=your_user;Password=your_password"
      },
      "JWT": {
        "Key": "YOUR_SUPER_SECRET_KEY_MUST_BE_LONG_ENOUGH",
        "Issuer": "BlogApi",
        "Audience": "BlogApiUser",
        "Duration": 60
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

3.  **Apply Migrations:**
    Open your terminal in the solution directory and run the following command to create the database and tables:
    ```bash
    dotnet ef database update --project Blog.Infrastructure --startup-project BlogApi
    ```
    *Note: The project already includes migrations for initial create and seeding roles.*

4.  **Run the Application:**
    ```bash
    dotnet run --project BlogApi
    ```

## 📖 API Documentation

This project uses **Scalar** for API documentation. Once the application is running (in Development environment), you can access the documentation at:
http://localhost:5198/scalar/v1

*(Check your console for the exact port if different)*.

## 🔗 Endpoints Overview

### Auth (`/blog/auth`)
* `POST /register`: Register a new user.
* `POST /login`: Authenticate user.
* `POST /refresh-token`: Refresh expired access token.

### Posts (`/api/posts`)
* `GET /all-posts`: Get all posts (Public).
* `GET /my-posts`: Get posts for the current user.
* `GET /post/{id}`: Get a specific post.
* `POST /create-post`: Create a new post.
* `PUT /update-post/{id}`: Update an existing post.
* `DELETE /delete/{id}`: Delete a post.

### Comments (`/api/comments`)
* `GET /post/{postId}`: Get comments for a specific post.
* `POST /`: Add a comment.
* `PUT /{id}`: Update a comment.
* `DELETE /{id}`: Delete a comment.
