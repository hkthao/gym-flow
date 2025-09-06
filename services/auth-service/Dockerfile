# auth-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/auth-service/auth-service.csproj", "./"]
RUN dotnet restore "auth-service.csproj"
COPY services/auth-service/. .
WORKDIR "/src"
RUN dotnet build "auth-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5003
ENTRYPOINT ["dotnet", "auth-service.dll"]