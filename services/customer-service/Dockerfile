# customer-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/customer-service/src", "src/"]
COPY ["services/customer-service/tests", "tests/"]
COPY ["services/customer-service/CustomerService.sln", "./"]
RUN dotnet restore "CustomerService.sln"
COPY ["services/customer-service/.", "."]
WORKDIR "/src/src/CustomerService.Api"
RUN dotnet build "CustomerService.Api.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5001
ENTRYPOINT ["dotnet", "CustomerService.Api.dll"]
