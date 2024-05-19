# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS publish

WORKDIR /src
COPY ["Heimdall.Api/Heimdall.Api.csproj", "Heimdall.Api/"]
COPY ["Heimdall.Application/Heimdall.Application.csproj", "Heimdall.Application/"]
COPY ["Heimdall.Domain/Heimdall.Domain.csproj", "Heimdall.Domain/"]
COPY ["Heimdall.Domain.Tests/Heimdall.Domain.Tests.csproj", "Heimdall.Domain.Tests/"]
COPY ["Heimdall.Infra.Data/Heimdall.Infra.Data.csproj", "Heimdall.Infra.Data/"]
COPY ["Heimdall.Infra.IoC/Heimdall.Infra.IoC.csproj", "Heimdall.Infra.IoC/"]

RUN dotnet restore "Heimdall.Api/"
RUN dotnet tool restore

COPY . .

WORKDIR "/src/Heimdall.Api"
RUN dotnet publish "Heimdall.Api.csproj" -c Release -o /app/publish --no-restore
WORKDIR "/src"

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN chmod -R a+w /app
USER app
ENV ASPNETCORE_URLS=http://+:8000
EXPOSE 8000
ENTRYPOINT ["dotnet", "Heimdall.Api.dll"]
