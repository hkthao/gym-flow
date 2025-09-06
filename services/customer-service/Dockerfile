# customer-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/customer-service/customer-service.csproj", "./"]
RUN dotnet restore "customer-service.csproj"
COPY services/customer-service/. .
WORKDIR "/src"
RUN dotnet build "customer-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5001
ENTRYPOINT ["dotnet", "customer-service.dll"]