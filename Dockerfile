# Container we use for final publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

# Build container
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Copy the code into the container
WORKDIR /src
# COPY [".env", "/.env"]
COPY ["NPaperless.API/NPaperless.API.csproj", "NPaperless.API/"]
COPY ["NPaperless.BL/NPaperless.BL.csproj", "NPaperless.BL/"]
COPY ["NPaperless.BL.Entities/NPaperless.BL.Entities.csproj", "NPaperless.BL.Entities/"]
COPY ["NPaperless.BL.Interfaces/NPaperless.BL.Interfaces.csproj", "NPaperless.BL.Interfaces/"]
COPY ["NPaperless.SA/NPaperless.SA.csproj", "NPaperless.SA/"]
COPY ["NPaperless.SA.Interfaces/NPaperless.SA.Interfaces.csproj", "NPaperless.SA.Interfaces/"]
COPY ["NPaperless.DA.Entities/NPaperless.DA.Entities.csproj", "NPaperless.DA.Entities/"]
COPY ["NPaperless.DA.Interfaces/NPaperless.DA.Interfaces.csproj", "NPaperless.DA.Interfaces/"]
COPY ["NPaperless.DA.Sql/NPaperless.DA.Sql.csproj", "NPaperless.DA.Sql/"]

# NuGet restore
RUN dotnet restore "NPaperless.API/NPaperless.API.csproj"
COPY ["NPaperless.API/", "NPaperless.API/"]
RUN dotnet restore "NPaperless.BL/NPaperless.BL.csproj"
COPY ["NPaperless.BL/", "NPaperless.BL/"]
RUN dotnet restore "NPaperless.SA/NPaperless.SA.csproj"
COPY ["NPaperless.SA/", "NPaperless.SA/"]
RUN dotnet restore "NPaperless.SA.Interfaces/NPaperless.SA.Interfaces.csproj"
COPY ["NPaperless.SA.Interfaces/", "NPaperless.SA.Interfaces/"]
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