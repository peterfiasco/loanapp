# Loan Management System

## Overview
A web-based Loan Application System using .NET 9, Entity Framework, Blazor, and Dependency Injection. The application manages loan applications with full CRUD functionality.

## Architecture
The solution uses a clean architecture with three projects:
- **LoanManagementSystem.Core**: Domain models and interfaces
- **LoanManagementSystem.Infrastructure**: Data access, implementations, and migrations
- **LoanManagementSystem.Web**: Blazor UI components and application entry point

## Features
- Entity Framework Core with SQL Server database
- Blazor UI with CRUD operations for loan applications
- Dependency Injection pattern
- Form validation
- Clean architecture with separation of concerns

## Setup Instructions
1. Ensure SQL Server Express is installed
2. Update connection string in appsettings.json if needed
3. Run `dotnet ef database update` to create the database
4. Run `dotnet run` from the LoanManagementSystem.Web directory

## Requirements Implemented
- LoanApplication entity with all required properties
- DbContext and migrations for database operations
- CRUD operations via service layer
- Blazor UI components for managing loan applications
- Dependency Injection with interfaces and implementations
- Data validation
