# LoginSystem API

## Project Status
🚧 **In Progress** 🚧

This project is currently under development. New features and improvements are being implemented, and this README will be updated accordingly.

## Overview
LoginSystem API is a .NET Core web API that aims to provide a secure authentication system. The system will utilize JWT (JSON Web Token) for authentication and Hash Salt encryption for password storage to ensure the security of user data.

## Features
- User Registration and Login
- JWT-based Authentication
- Password encryption using Hash and Salt
- Role-based Access Control (Admin, User)

## Technologies Used
- **ASP.NET Core**: For building the web API
- **Entity Framework Core**: For data access and ORM (Object-Relational Mapping)
- **SQLite**: As the database for this project
- **JWT (JSON Web Token)**: For secure authentication
- **Hashing and Salting**: For securely storing passwords

## Authentication
The LoginSystem API uses JWT for authentication. After successful login, a JWT token will be generated for the user, which can be used to access protected routes in the API. JWT ensures that each request is authorized, without the need to store session data on the server.
