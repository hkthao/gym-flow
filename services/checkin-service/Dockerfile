# checkin-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update && apt-get install -y curl
RUN curl -sSL https://dot.net/v1/dotnet-install.sh -o /usr/local/bin/dotnet-install.sh && chmod +x /usr/local/bin/dotnet-install.sh
RUN /usr/local/bin/dotnet-install.sh --version 8.0.100 --install-dir /usr/share/dotnet
WORKDIR /src
COPY ["checkin-service.csproj", "./"]
RUN dotnet restore "checkin-service.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "checkin-service.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 5002
ENTRYPOINT ["dotnet", "checkin-service.dll"]