# customer-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["customer-service/customer-service.csproj", "customer-service/"]
RUN dotnet restore "customer-service/customer-service.csproj"
COPY . .
WORKDIR "/src/customer-service"
RUN dotnet build "customer-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5001
ENTRYPOINT ["dotnet", "customer-service.dll"]