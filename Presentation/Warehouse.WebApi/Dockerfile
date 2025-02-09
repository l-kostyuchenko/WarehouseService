#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/Warehouse.WebApi/Warehouse.WebApi.csproj", "Presentation/Warehouse.WebApi/"]
COPY ["Core/Warehouse.Application/Warehouse.Application.csproj", "Core/Warehouse.Application/"]
COPY ["Core/Warehouse.Domain/Warehouse.Domain.csproj", "Core/Warehouse.Domain/"]
COPY ["Infrastructure/Warehouse.Persistence/Warehouse.Persistence.csproj", "Infrastructure/Warehouse.Persistence/"]
RUN dotnet restore "./Presentation/Warehouse.WebApi/./Warehouse.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/Warehouse.WebApi"
RUN dotnet build "./Warehouse.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Warehouse.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Warehouse.WebApi.dll"]