# 🏋️‍♂️ Gym Management System

A full-featured **ASP.NET Core MVC** web application built with **.NET 10** as part of the **ITI coursework**.

The application is designed using **Clean Architecture** principles and the **Repository Pattern** to efficiently manage gym operations, trainers, members, classes, and class enrollments with role-based access control.

---

## 🚀 Features

### 👨‍💼 Admin Capabilities

* **Trainers Management:** Full CRUD operations to add, update, view, and delete trainers.
* **Classes Management:** Create, configure, and manage gym classes and assign trainers.
* **Members Management:** Full CRUD control over gym member profiles.
* **Enrollment System:** Easily register members into specific gym classes.

### 🏋️‍♂️ Trainer Capabilities

* **Class Schedule View:** Access gym classes and view their schedules.
* **Dynamic Filtering:** Filter classes by specific trainers instantly using **AJAX** without a full page reload.
* **Enrolled Members List:** View registered members directly inside each class details page.

---

## 🛠️ Tech Stack

* **Framework:** ASP.NET Core MVC (.NET 10)
* **Language:** C#
* **Architecture:** Clean Architecture
* **Design Pattern:** Repository Pattern
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Authentication:** Session-Based Authentication
* **Authorization:** Custom Authorization Filters
* **Frontend:** HTML5, CSS3, JavaScript
* **UI Framework:** Bootstrap 5
* **Icons:** Bootstrap Icons
* **Asynchronous Requests:** AJAX

---

## 🏗️ Architecture

The project follows **Clean Architecture** principles to separate responsibilities and make the application easier to maintain, test, and extend.

### Main Layers

* **Presentation Layer:** ASP.NET Core MVC Controllers and Views.
* **Business Logic Layer:** Application services and business rules.
* **Data Access Layer:** Entity Framework Core and Repository implementations.
* **Domain Layer:** Core entities and business models.

---

## 💻 Getting Started

### Prerequisites

Make sure you have the following installed:

* **.NET 10.0 SDK**
* **SQL Server / SQL Server LocalDB**
* **Visual Studio 2022** or **VS Code**
* **Entity Framework Core Tools**

---

## ⚙️ Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/Youssef-Ym/ItiFinalProjectMvcGym.git
```

### 2. Navigate to the Project Directory

```bash
cd ItiFinalProjectMvcGym
```

### 3. Configure the Database

Update the connection string in `appsettings.json` according to your SQL Server configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=GymManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Apply Entity Framework Core Migrations

Run the following command to create/update the database:

```bash
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

Then open the URL displayed in the terminal or run the project through Visual Studio.

---

## 🔐 Default Credentials

| Role        | Email             | Password       |
| ----------- | ----------------- | -------------- |
| **Admin**   | `admin@gym.com`   | `Admin123`     |
| **Trainer** | `trainer@gym.com` | `Any password` |

> **Note:** Make sure these accounts exist in the database before attempting to log in.

---

## 📂 Main Modules

The system contains several main modules:

* 👨‍💼 **Admin Dashboard**
* 🏋️ **Trainers Management**
* 👥 **Members Management**
* 📚 **Classes Management**
* 📝 **Class Enrollment**
* 🔎 **Dynamic Class Filtering**
* 👤 **Role-Based Access Control**
* 📅 **Class Scheduling**
* 👥 **Enrolled Members Management**

---

## 🎯 Project Goals

The main goal of this project is to provide a simple and efficient gym management system while applying real-world software engineering concepts such as:

* Clean Architecture
* Repository Pattern
* Separation of Concerns
* Entity Framework Core
* Role-Based Authorization
* Session Management
* AJAX
* CRUD Operations
* Database Relationships
* MVC Design Pattern

---

## 👨‍💻 Author

**Youssef Mohamed Abdelsalam**

GitHub:
https://github.com/Youssef-Ym

---

## 📝 License

This project was developed for **educational purposes** as part of the **ITI (Information Technology Institute) Software Engineering curriculum**.
