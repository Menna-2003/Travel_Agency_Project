# Travel Agency Website

Welcome to the **Travel Agency** project! This web application is built using **ASP.NET Core 8** and provides a seamless platform for users to explore and book tours. The project leverages Microsoft's **SQL Server** for data storage and **Identity Framework** for user authentication and role management.
[Project Demo](https://drive.google.com/file/d/1D_iVPe9MoiVwxBnw9oKj396uNBsUGcBX/view?usp=sharing)
 
## Features

### Admin
- **Add, Edit, and Delete Tours**: Admins can manage all tours available on the platform, keeping the offerings up-to-date.

### User
- **Book Tours**: Users can browse available tours and book their desired ones.
- **Cart System**: Add tours to a personal cart for easy checkout.
- **Favorites**: Save favorite tours for future bookings.
- **Secure Authentication**: Users can register and log in with secure credentials.

## Technology Stack
- **Backend**: ASP.NET Core 8
- **Frontend**: Razor Pages
- **Database**: Microsoft SQL Server
- **Authentication**: ASP.NET Core Identity Framework

## User Roles
- **Admin**: Full control over the tours and user management.
- **Customer**: Can browse, book, and manage favorite tours.

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/travel-agency.git
   ```
2. Restore dependencies and set up your database with SQL Server.
   - Go to tools => NuGet Package manager => manage NuGet package for solution
   - install:
        - Microsoft.AspNetCore.Identity.EntityFrameworkCore
        - Microsoft.EntityFrameworkCore
        - Microsoft.EntityFrameworkCore.SqlServer
        - Microsoft.EntityFrameworkCore.Tools
   - Go to appsettings.json, i the connection string define your server
     
3. Run the application using Visual Studio

## Running the project

First you will see no tours so you need to add some. 
Register and the first account you register with will be the admin, any other user will be a normal user.
add some Tours to the database then explore the project.




