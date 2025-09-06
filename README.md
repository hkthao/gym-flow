# gym-flow
GymFlow - Ứng dụng quản lý khách hàng và check-in/out cho phòng gym, xây dựng theo kiến trúc microservices và CI/CD.

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

To run the BDD tests for the `ai-face-service`, navigate to the `services/ai-face-service` directory and run pytest:

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

### Branch Protection

To ensure the stability of the `main` and `develop` branches, it is crucial to set up branch protection rules. These rules prevent direct pushes and require that all pull requests pass the CI/CD checks before they can be merged.

To configure branch protection:

1.  Go to your repository's **Settings** tab.
2.  Click on **Branches** in the left sidebar.
3.  Click **Add rule**.
4.  In the **Branch name pattern**, enter `main` or `develop`.
5.  Enable the following options:
    *   **Require a pull request before merging.**
    *   **Require status checks to pass before merging.**
    *   Select the **`lint-python`**, **`test-python`**, **`build-and-push-python`**, **`lint-dotnet`**, **`test-dotnet`** and **`build-and-push-dotnet`** jobs from the list of status checks.
6.  Click **Create**.