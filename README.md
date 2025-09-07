# gym-flow
GymFlow - Ứng dụng quản lý khách hàng và check-in/out cho phòng gym, xây dựng theo kiến trúc microservices và CI/CD.

## Local Development Workflow

This project is set up for a flexible local development experience, allowing you to run backend and frontend services independently.

### Running Backend Services

To build and run all backend services (including the database):

```bash
# Build and start all backend containers
docker-compose up --build -d
```

The services will be accessible at:
- AI Face Service: `http://localhost:5000`
- Customer Service: `http://localhost:5001`
- Checkin Service: `http://localhost:5002`
- Auth Service: `http://localhost:5003`

### Running Frontend Service (Hot-Reload)

For frontend development with hot-reloading, it's recommended to run the Vue dev server directly. This connects to the running backend containers.

1.  Navigate to the `admin-dashboard` directory:
    ```bash
    cd services/admin-dashboard
    ```
2.  Install dependencies:
    ```bash
    npm install
    ```
3.  Start the development server:
    ```bash
    npm run dev
    ```
    The dashboard will be accessible at `http://localhost:5173`.

### Running Frontend Service (Docker)

To build and run the frontend as a Docker container (without hot-reload):

```bash
# Build and start the frontend container
docker-compose -f docker-compose.frontend.yml up --build -d
```
The dashboard will be accessible at `http://localhost:8081`.
## Running Tests

### Python (ai-face-service)

To run the BDD tests for the `ai-face-service`, navigate to the `services/ai-face-service` directory and run pytest:

```bash
cd services/ai-face-service
pytest
```

### ASP.NET Core (customer-service, checkin-service, auth-service)

For ASP.NET Core services, navigate to each service directory and run dotnet test. Note that `customer-service` now includes both unit and integration tests.

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

The CI/CD pipeline is configured using GitHub Actions and defined in the `.github/workflows/ci-cd.yml` file. The pipeline utilizes the latest versions of Docker-related GitHub Actions for improved stability and features. It consists of the following stages:

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

## Monitoring and Logging with Prometheus and Grafana

This project integrates Prometheus for metrics collection and Grafana for visualization, along with centralized JSON logging.

### Running Prometheus and Grafana

To run Prometheus and Grafana alongside your services, use the `docker-compose.override.yml` file:

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

This command will start all your microservices, plus Prometheus and Grafana.

### Accessing Grafana Dashboard

Once Grafana is running, you can access its dashboard:

1.  Open your web browser and navigate to `http://localhost:3000`.
2.  Log in with the default credentials: Username `admin`, Password `admin`. You will be prompted to change the password on your first login.
3.  **Add Prometheus Data Source:**
    *   Click on the "Configuration" (gear icon) on the left sidebar.
    *   Select "Data sources".
    *   Click "Add data source".
    *   Choose "Prometheus".
    *   Set the "Name" to `Prometheus`.
    *   Set the "HTTP" -> "URL" to `http://prometheus:9090`.
    *   Click "Save & Test".
4.  You can now create dashboards to visualize your application metrics. Refer to the Grafana documentation for detailed dashboard creation.

### Viewing Centralized Logs

All microservices are configured to output logs in JSON format, which are collected by Docker's `json-file` logging driver. You can view these centralized logs using `docker-compose logs`:

```bash
docker-compose logs <service_name>
```

Replace `<service_name>` with `ai-face-service`, `auth-service`, `checkin-service`, or `customer-service`.

To view all logs in real-time:

```bash
docker-compose logs -f
```