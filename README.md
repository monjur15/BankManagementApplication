## Overview
The Bank Management App simulates core banking functionalities by providing a centralized system for account management, transactions, and reporting. The backend API serves as the core of the system, enabling seamless interaction for various user roles, including customers, bank staff, and admins.

## Key Features
> Centralized account management.
> Secure user authentication and authorization using JWT tokens.
> Role-based access control for Admin, Bank Staff, and Customers.
> Bank Staff-exclusive account creation and authorization.
> Endpoints to handle account and transaction operations.

## Prerequisites
> .NET Core SDK installed.
> MsSQL Server configured and running.
> A tool like Postman or Swagger for API testing.

## Installation Guide
1. Clone the Repository
Clone the GitHub repository to your local machine: git clone <repository-url>
Navigate to the project directory:cd <project-folder-name>

2. Configure the Database
The application uses a code-first approach with Entity Framework. To set up the database:
>Locate the appsettings.json file in the project.
>Update the Data Source value in the ConnectionStrings section with your database server name. For example:"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BankManagementDB;Trusted_Connection=True;"
}
3. Apply Database Migrations
>>Run the following command in the directory containing the .csproj file to create the database: dotnet ef database update

4. Run the Application




## Testing the Endpoints

We recommend using Postman to test the API endpoints:

1. Import the API collection or manually configure requests.

2. Test the following functionalities:
> User Registration and Login
> Account Creation (Bank Staff only)
> Viewing Accounts
> Transaction Operations

## User Roles and Permissions

1. Admin:
Manage system configurations.
Oversee all operations.

2. Bank Staff:
Create and authorize accounts for users.
Manage customer accounts.

3. Customer:
Access personal bank accounts.
Perform transactions.

## Authentication and Authorization
> JWT Tokens are used to authenticate and authorize users.
> Each role has specific permissions managed through claims in the JWT.

## Important Notes

* Only Bank Staff can create and authorize bank accounts for users, including themselves.
* Any user can register into the system but must have an authorized account to access banking functionalities.
* Ensure the Data Source in appsettings.json matches your MsSQL configuration before applying migrations.



## Contribution
Contributions are welcome! Please fork the repository and create a pull request for any improvements or feature additions.
