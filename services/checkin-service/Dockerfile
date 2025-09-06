# checkin-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["services/checkin-service/checkin-service.csproj", "./"]
RUN dotnet restore "checkin-service.csproj"
COPY services/checkin-service/. .
WORKDIR "/src"
RUN dotnet build "checkin-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5002
ENTRYPOINT ["dotnet", "checkin-service.dll"]