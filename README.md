# Loan Application System

## Overview
A .NET 9 Blazor application for managing loan applications with Entity Framework Core and SQL Server.

## Architecture
The solution uses a clean architecture with three projects:
- **LoanManagementSystem.Core**: Domain models and interfaces
- **LoanManagementSystem.Infrastructure**: Data access, implementations, and migrations
- **LoanManagementSystem.Web**: Blazor UI components and application entry point

## Features
- Complete CRUD operations for loan applications
- Blazor UI with form validation
- Clean architecture with dependency injection
- Entity Framework Core with SQL Server

## Setup Instructions
1. Ensure SQL Server is installed
2. Update connection string in appsettings.json if needed
3. Run the application - migrations will be applied automatically

## Technologies
- .NET 9
- Entity Framework Core
- Blazor
- SQL Server Express

