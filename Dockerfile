# Container we use for final publish
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build container
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Copy the code into the container
WORKDIR /src
COPY [".env", "/.env"]
COPY ["src/NPaperless.Services/NPaperless.Services.csproj", "NPaperless.Services/"]
COPY ["src/NPaperless.Core/NPaperless.Core.csproj", "NPaperless.Core/"]
COPY ["src/NPaperless.Core.Entities/NPaperless.Core.Entities.csproj", "NPaperless.Core.Entities/"]
COPY ["src/NPaperless.Core.Interfaces/NPaperless.Core.Interfaces.csproj", "NPaperless.Core.Interfaces/"]

# NuGet restore
RUN dotnet restore "NPaperless.Services/NPaperless.Services.csproj"
COPY ["src/NPaperless.Services", "NPaperless.Services/"]
RUN dotnet restore "NPaperless.Core/NPaperless.Core.csproj"
COPY ["src/NPaperless.Core", "NPaperless.Core/"]
RUN dotnet restore "NPaperless.Core.Entities/NPaperless.Core.Entities.csproj"
COPY ["src/NPaperless.Core.Entities", "NPaperless.Core.Entities/"]
RUN dotnet restore "NPaperless.Core.Interfaces/NPaperless.Core.Interfaces.csproj"
COPY ["src/NPaperless.Core.Interfaces", "NPaperless.Core.Interfaces/"]

# Build the API
WORKDIR "/src/NPaperless.Services"
RUN dotnet build "NPaperless.Services.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
RUN dotnet publish "NPaperless.Services.csproj" -c Release -o /app/publish

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NPaperless.Services.dll"]
