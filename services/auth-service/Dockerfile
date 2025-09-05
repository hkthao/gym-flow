# auth-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["auth-service/auth-service.csproj", "auth-service/"]
RUN dotnet restore "auth-service/auth-service.csproj"
COPY . .
WORKDIR "/src/auth-service"
RUN dotnet build "auth-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5003
ENTRYPOINT ["dotnet", "auth-service.dll"]