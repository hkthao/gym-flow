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

## Continuous Integration / Continuous Delivery (CI/CD)

Our CI/CD pipeline automates the process of building, testing, and pushing Docker images for all microservices in the GymFlow project. This ensures code quality, faster deployments, and a consistent development workflow.

### Workflow Overview

The CI/CD pipeline is configured using GitHub Actions and defined in the `.github/workflows/ci-cd.yml` file. It consists of the following stages:

1.  **Linting**: Checks code for style and potential errors.
2.  **Unit Tests**: Runs unit tests for each service to ensure functionality.
3.  **Build**: Builds Docker images for all microservices.
4.  **Docker Push**: Pushes the built Docker images to a container registry.

### Triggering the Pipeline

The CI/CD pipeline is automatically triggered on the following events:

*   **`push` to `main` or `develop` branches**: Any direct push to these branches will initiate a full CI/CD run.
*   **`pull_request` targeting `main` or `develop` branches**: When a pull request is opened or updated against `main` or `develop`, the pipeline will run to validate the changes before merging.

### Checking Pipeline Status and Logs

To monitor the progress and view logs of the CI/CD pipeline runs:

1.  Navigate to the "Actions" tab in your GitHub repository.
2.  Select the "CI/CD Pipeline" workflow from the list.
3.  Click on a specific workflow run to view its detailed steps and logs.

### Important Notes

*   **Branch Protection**: It is highly recommended to set up branch protection rules for the `main` and `develop` branches in your GitHub repository settings. This will prevent direct pushes and ensure that Pull Requests can only be merged after all CI checks have passed successfully.
*   **Pull Request Merge**: Pull Requests should only be merged into `main` or `develop` once all associated CI/CD checks have passed.