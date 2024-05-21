#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Mardul.Recipes.Api/Mardul.Recipes.Api.csproj", "Mardul.Recipes.Api/"]
COPY ["Mardul.Recipes.Core/Mardul.Recipes.Core.csproj", "Mardul.Recipes.Core/"]
COPY ["Mardul.Recipes.Data/Mardul.Recipes.Infrastructure.csproj", "Mardul.Recipes.Data/"]
RUN dotnet restore "./Mardul.Recipes.Api/Mardul.Recipes.Api.csproj"
COPY . .
WORKDIR "/src/Mardul.Recipes.Api"
RUN dotnet build "./Mardul.Recipes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mardul.Recipes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mardul.Recipes.Api.dll"]