# Use the official ASP.NET runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copy the project file for BackendServer1 and the shared Database library
COPY ["BackendServer1/BackendServer1.csproj", "BackendServer1/"]
COPY ["ServerLoadBalancerSimulation.Database/ServerLoadBalancerSimulation.Database.csproj", "ServerLoadBalancerSimulation.Database/"]

# Restore dependencies for BackendServer1 (this will also restore the referenced Database project)
RUN dotnet restore "BackendServer1/BackendServer1.csproj"

# Copy the rest of the source code for both projects
COPY BackendServer1/ BackendServer1/
COPY ServerLoadBalancerSimulation.Database/ ServerLoadBalancerSimulation.Database/

# Build BackendServer1
RUN dotnet build "BackendServer1/BackendServer1.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BackendServer1/BackendServer1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendServer1.dll"]
