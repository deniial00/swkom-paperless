# Container we use for final publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8081

# Build container
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Copy the code into the container
WORKDIR /src
# COPY [".env", "/.env"]
COPY ["NPaperless.API/NPaperless.API.csproj", "NPaperless.API/"]
COPY ["NPaperless.BL/NPaperless.BL.csproj", "NPaperless.BL/"]
COPY ["NPaperless.BL.Entities/NPaperless.BL.Entities.csproj", "NPaperless.BL.Entities/"]
COPY ["NPaperless.BL.Interfaces/NPaperless.BL.Interfaces.csproj", "NPaperless.BL.Interfaces/"]
COPY ["NPaperless.DA.Entities/NPaperless.DA.Entities.csproj", "NPaperless.DA.Entities/"]
COPY ["NPaperless.DA.Interfaces/NPaperless.DA.Interfaces.csproj", "NPaperless.DA.Interfaces/"]
COPY ["NPaperless.DA.Sql/NPaperless.DA.Sql.csproj", "NPaperless.DA.Sql/"]

# NuGet restore
RUN dotnet restore "NPaperless.API/NPaperless.API.csproj"
COPY ["NPaperless.API/", "NPaperless.API/"]
RUN dotnet restore "NPaperless.BL/NPaperless.BL.csproj"
COPY ["NPaperless.BL/", "NPaperless.BL/"]
RUN dotnet restore "NPaperless.BL.Entities/NPaperless.BL.Entities.csproj"
COPY ["NPaperless.BL.Entities/", "NPaperless.BL.Entities/"]
RUN dotnet restore "NPaperless.BL.Interfaces/NPaperless.BL.Interfaces.csproj"
COPY ["NPaperless.BL.Interfaces/", "NPaperless.BL.Interfaces/"]
RUN dotnet restore "NPaperless.DA.Entities/NPaperless.DA.Entities.csproj"
COPY ["NPaperless.DA.Entities/", "NPaperless.DA.Entities/"]
RUN dotnet restore "NPaperless.DA.Interfaces/NPaperless.DA.Interfaces.csproj"
COPY ["NPaperless.DA.Interfaces/", "NPaperless.DA.Interfaces/"]
RUN dotnet restore "NPaperless.DA.Sql/NPaperless.DA.Sql.csproj"
COPY ["NPaperless.DA.Sql/", "NPaperless.DA.Sql/"]

# Build the API
WORKDIR "/src/NPaperless.API"
RUN dotnet build "NPaperless.API.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
WORKDIR "/src/NPaperless.API"
RUN dotnet publish "NPaperless.API.csproj" -c Release -o /app/publish

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NPaperless.API.dll"]







# # Container we use for final publish
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /app

# COPY *.sln .
# COPY NPaperless.API/*.csproj ./NPaperless.API/
# COPY NPaperless.BL/*.csproj ./NPaperless.BL/
# COPY NPaperless.BL.Entities/*.csproj ./NPaperless.BL.Entities/
# COPY NPaperless.BL.Interfaces/*.csproj ./NPaperless.BL.Interfaces/

# RUN dotnet restore

# COPY NPaperless.API/. ./NPaperless.API/
# COPY NPaperless.BL/. ./NPaperless.BL/
# COPY NPaperless.BL.Entities/. ./NPaperless.BL.Entities/
# COPY NPaperless.BL.Interfaces/. ./NPaperless.BL.Interfaces/

# WORKDIR /app/NPaperless.API
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
# WORKDIR /app

# COPY --from=build /app/NPaperless.API/out ./
#COPY entrypoint.sh .

# ENTRYPOINT ["dotnet", "NPaperless.API.dll"]




















# ENTRYPOINT ["tail", "-f", "/dev/null"]
