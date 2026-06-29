# 📋 SampleEmployeesManagementSystem
### Simple CRUD Application in C# with ASP.NET Core MVC

[![ASP.NET](https://img.shields.io/badge/ASP.NET-async%20framework-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/en-us/apps/aspnet)
[![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-336791?style=flat&logo=postgresql)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Deployed%20With-Docker-2496ED?style=flat&logo=docker)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Stable-success)]()
[![Platform](https://img.shields.io/badge/Platform-Linux%20%28Debian%29-E95420?style=flat&logo=linux)](https://www.debian.org/)

---

## 📖 About the Project

This project was developed as part of our end-of-semester assignment. It demonstrates how to build a simple **CRUD (Create, Read, Update, Delete)** web application using **C#** and the **ASP.NET Core MVC** framework, with **PostgreSQL** as the database backend.

The work is inspired by [this tutorial video](https://www.youtube.com/watch?v=9LfI5RwOToM), adapted for a **Linux (Debian)** environment. Since the original tutorial relies heavily on Visual Studio's graphical interface (e.g., for scaffolding, migrations, and package management), every step here is reproduced entirely **via the command line (CLI)** — making it compatible with any Linux machine without a GUI IDE.

This project is available on my github in this [link](https://github.com/darixsamani/csharp-school-project)

> All commands used throughout the project are documented here for full reproducibility.

---

## ✨ Features

- Full CRUD operations for employee records
- MVC architecture with auto-generated controllers and views (scaffolding)
- PostgreSQL integration via Entity Framework Core
- Responsive UI with Bootstrap and Font Awesome (managed via LibMan)
- Docker-ready deployment
- 100% CLI-based setup — no Visual Studio required

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET) |
| Framework | ASP.NET Core MVC |
| ORM | Entity Framework Core |
| Database | PostgreSQL |
| UI Libraries | Bootstrap, Font Awesome |
| Package Manager | NuGet, LibMan |
| Deployment | Docker |
| OS | Debian Linux |

---

## ✅ Prerequisites

Before getting started, make sure the following are installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (version 6.0 or later)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Docker](https://www.docker.com/) *(optional, for containerized deployment)*
- A terminal (bash, zsh, etc.)

Verify your .NET installation:

```bash
dotnet --version
```

---

## 🚀 Installation & Setup

Follow the steps below in order. Each section is self-contained and explains what it does and why.

### 1. Clone the Repository

```bash
git clone https://github.com/darixsamani/csharp-school-project
cd csharp-school-project
```

---

### 2. Configure the Database Connection

Before running anything, open `appsettings.json` and set your PostgreSQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=EmployeesDb;Username=your_user;Password=your_password"
  }
}
```

> Replace `your_user` and `your_password` with your actual PostgreSQL credentials.

---

### 3. Install EF Core CLI Tools

Entity Framework Core's CLI (`dotnet-ef`) is used to manage database migrations.

```bash
dotnet tool install --global dotnet-ef
```

Then make sure the global tools directory is on your PATH (add this to your `~/.bashrc` or `~/.zshrc` to persist it):

```bash
export PATH=$PATH:$HOME/.dotnet/tools
```

Verify the installation:

```bash
dotnet ef --version
```

---

### 4. Add Required NuGet Packages

From the project's root directory (where the `.csproj` file is located):

```bash
# EF Core design-time support (required for migrations and scaffolding)
dotnet add package Microsoft.EntityFrameworkCore.Design

# PostgreSQL provider for EF Core
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# Scaffolding and code generation support
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

### 5. Run Database Migrations

Create the initial migration (this generates the migration files from your models):

```bash
dotnet ef migrations add InitialCreate
```

Apply the migration to create the database schema:

```bash
dotnet ef database update
```

> After this step, your PostgreSQL database should have the `Employees` table ready.

---

### 6. Install the Scaffolding Tool

The ASP.NET Code Generator automatically generates controllers and views from your models — the CLI equivalent of Visual Studio's "Add Controller" wizard.

```bash
dotnet tool install -g dotnet-aspnet-codegenerator
```

Then scaffold the `EmployeesController` with full CRUD views:

```bash
dotnet aspnet-codegenerator controller \
  -name EmployeesController \
  -m Employee \
  -dc ApplicationDbContext \
  -outDir Controllers \
  -udl -f
```

**What this does:**

| Flag | Meaning |
|---|---|
| `-name EmployeesController` | Name of the generated controller |
| `-m Employee` | The model class to scaffold from |
| `-dc ApplicationDbContext` | The EF Core `DbContext` class to use |
| `-outDir Controllers` | Output directory for the controller file |
| `-udl` | Use the default layout (`_Layout.cshtml`) |
| `-f` | Force overwrite if files already exist |

---

### 7. Install & Configure LibMan (Client-Side Libraries)

LibMan is the CLI tool for managing front-end libraries (Bootstrap, Font Awesome, etc.) without npm or yarn.

**Install LibMan:**

```bash
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

Verify:

```bash
libman --version
```

**Initialize LibMan in your project** *(one-time, from the project root)*:

```bash
libman init
```

**Install Bootstrap:**

```bash
libman install bootstrap -p cdnjs -d wwwroot/lib/bootstrap
```

**Install Font Awesome:**

```bash
libman install font-awesome -p cdnjs -d wwwroot/lib/font-awesome
```

**Reference the libraries in your layout**

In `Views/Shared/_Layout.cshtml`, add the following inside the `<head>` tag:

```html
<!-- Bootstrap -->
<link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />

<!-- Font Awesome -->
<link rel="stylesheet" href="~/lib/font-awesome/css/all.css" />
```

---

## ▶️ Running the Application

Once everything is configured, start the app with:

```bash
dotnet run --reload
```

Then open your browser and navigate to:

or `http://localhost:5186/` for HTTPS.

---

> Make sure your `appsettings.json` or environment variables point to an accessible PostgreSQL instance from within the container.


---

## 👥 Authors

| Name | Role |
|---|---|
| Darix SAMANI SIEWE | Student at ENSET DOUALA |

> Project submitted for the **Normal Session** — Academic Year 2025/2026  
> Institution: **ENSET de Douala, Université de Douala**

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).