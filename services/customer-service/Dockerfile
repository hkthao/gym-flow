# customer-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/CustomerService.Api/CustomerService.Api.csproj", "CustomerService.Api/"]
COPY ["src/CustomerService.Application/CustomerService.Application.csproj", "CustomerService.Application/"]
COPY ["src/CustomerService.Domain/CustomerService.Domain.csproj", "CustomerService.Domain/"]
COPY ["src/CustomerService.Infrastructure/CustomerService.Infrastructure.csproj", "CustomerService.Infrastructure/"]
COPY ["CustomerService.sln", "./"]

RUN dotnet restore "CustomerService.sln"
COPY . .
WORKDIR "/src/src/CustomerService.Api"
RUN dotnet build "CustomerService.Api.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5001
ENTRYPOINT ["dotnet", "CustomerService.Api.dll"]
