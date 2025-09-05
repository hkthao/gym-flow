# GymFlow Project

This repository contains the GymFlow microservices application.

## Getting Started with Docker Compose

To build and run the services using Docker Compose:

1.  Make sure you have Docker and Docker Compose installed.
2.  Navigate to the root of this project:
    ```bash
    cd gym-flow
    ```
3.  Build the Docker images for all services:
    ```bash
    docker-compose build
    ```
4.  Start all services:
    ```bash
    docker-compose up
    ```
    The services will be accessible at:
    - AI Face Service: `http://localhost:5000`
    - Customer Service: `http://localhost:5001`
    - Checkin Service: `http://localhost:5002`
    - Auth Service: `http://localhost:5003`

## Running Tests

### Python (ai-face-service)

Navigate to the `ai-face-service` directory and run pytest:

```bash
cd services/ai-face-service
pytest
```

### ASP.NET Core (customer-service, checkin-service, auth-service)

Navigate to each service directory and run dotnet test:

```bash
cd services/customer-service
dotnet test

cd services/checkin-service
dotnet test

cd services/auth-service
dotnet test
```