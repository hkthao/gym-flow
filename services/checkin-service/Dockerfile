# checkin-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN dotnet-install.sh --version 8.0.100 --install-dir /usr/share/dotnet
WORKDIR /src
COPY ["services/checkin-service/checkin-service.csproj", "./"]
RUN dotnet restore "checkin-service.csproj"
COPY services/checkin-service/. .
WORKDIR "/src"
RUN dotnet build "checkin-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5002
ENTRYPOINT ["dotnet", "checkin-service.dll"]