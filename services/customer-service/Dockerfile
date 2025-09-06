FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file and restore dependencies
COPY services/customer-service/CustomerService.sln ./CustomerService.sln
COPY services/customer-service/src/CustomerService.Api/CustomerService.Api.csproj services/customer-service/src/CustomerService.Api/
COPY services/customer-service/src/CustomerService.Application/CustomerService.Application.csproj services/customer-service/src/CustomerService.Application/
COPY services/customer-service/src/CustomerService.Domain/CustomerService.Domain.csproj services/customer-service/src/CustomerService.Domain/
COPY services/customer-service/src/CustomerService.Infrastructure/CustomerService.Infrastructure.csproj services/customer-service/src/CustomerService.Infrastructure/

RUN dotnet restore ./CustomerService.sln

# Copy all project files and build
COPY services/customer-service/src/CustomerService.Api/. services/customer-service/src/CustomerService.Api/
COPY services/customer-service/src/CustomerService.Application/. services/customer-service/src/CustomerService.Application/
COPY services/customer-service/src/CustomerService.Domain/. services/customer-service/src/CustomerService.Domain/
COPY services/customer-service/src/CustomerService.Infrastructure/. services/customer-service/src/CustomerService.Infrastructure/

WORKDIR /src/services/customer-service/src/CustomerService.Api
RUN dotnet build "CustomerService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.Api.dll"]
