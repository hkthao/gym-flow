# customer-service/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN curl -sSL https://dot.net/v1/dotnet-install.sh -o /usr/local/bin/dotnet-install.sh && chmod +x /usr/local/bin/dotnet-install.sh
RUN /usr/local/bin/dotnet-install.sh --version 8.0.100 --install-dir /usr/share/dotnet
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