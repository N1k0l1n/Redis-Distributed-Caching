# Redis-Distributed-Caching

This repository demonstrates an application utilizing Redis distributed caching implemented with Vite React and .NET 6 using the template provided in Visual Studio 2022. Additionally, it includes instructions for setting up Redis on a Windows environment.

## Technologies Used

- Vite React
- .NET 6
- Redis

## Installation

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Node.js](https://nodejs.org/) (for Vite React)
- [Redis for Windows](https://redis.io/download) - Download and install Redis on Windows

### Steps to Run the Application

1. Clone this repository.

2. ### Backend (ASP.NET Core)

    - Open the solution in Visual Studio 2022.
    - Ensure Redis is installed and running on your Windows machine.
    - Build and run the ASP.NET Core application. This starts the backend server.

3. ### Frontend (Vite React)

    - Navigate to the `client` directory.
    - Install dependencies with `npm install` or `yarn install`.
    - Start the Vite React app with `npm run dev` or `yarn dev`.

4. Access the application:
    - The frontend should be accessible at `http://localhost:3000`.
    - Backend API endpoints are available as per the configured routes.

## Redis Setup (Windows)

- Download Redis for Windows from the [official Redis website](https://redis.io/download).
- Install Redis following the provided instructions.
- Start the Redis server.

## Redis Setup (Windows)

- Download Redis for Windows from the [official Redis website](https://redis.io/download).
- Install Redis following the provided instructions.
- Start the Redis server.

## Usage

Feel free to utilize this repository as a reference for implementing Redis distributed caching in your own projects. Customize and expand upon it according to your project's requirements.

## Contribution

Contributions are welcome! If you'd like to improve this project or add new features, feel free to open issues and pull requests. Follow the guidelines outlined in the [CONTRIBUTING.md](CONTRIBUTING.md) file.

## License

This project is licensed under the [MIT License](LICENSE). You are free to modify, distribute, and use the code in your own projects as per the terms of this license.
