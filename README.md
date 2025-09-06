# gym-flow
GymFlow - Ứng dụng quản lý khách hàng và check-in/out cho phòng gym, xây dựng theo kiến trúc microservices và CI/CD.

## Running Tests

### Python (ai-face-service)

To run the BDD tests for the `ai-face-service`, navigate to the `services/ai-face-service` directory and run pytest:

```bash
cd services/ai-face-service
pytest
```

### ASP.NET Core (aspnet-service)

To run the BDD tests for the `aspnet-service`, you will need to have the .NET SDK and SpecFlow installed. 

Navigate to the `services/aspnet-service` directory and run the following command:

```bash
dotnet test
```