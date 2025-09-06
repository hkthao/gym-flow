# ASP.NET Core Service Tests

This directory contains tests for the ASP.NET Core services, including Behavior-Driven Development (BDD) tests using SpecFlow and unit tests using xUnit.

## Directory Structure

- `Features/`: Contains Gherkin `.feature` files that describe the desired behavior of the services.
- `StepDefinitions/`: Contains C# step definition files that implement the scenarios defined in the `.feature` files.
- `UnitTests/`: Contains C# unit test files.

## Running Tests

To run all tests (BDD and Unit Tests) for this ASP.NET Core service, navigate to the service's test project directory (e.g., `services/aspnet-service/aspnet-service.Tests`) and run `dotnet test`:

```bash
cd services/aspnet-service/aspnet-service.Tests
dotnet test
```

## CI/CD Integration

These tests are designed to be integrated into the Continuous Integration/Continuous Delivery (CI/CD) pipeline. The `dotnet test` command can be executed as part of the CI/CD workflow to ensure code quality and functionality before deployment.
