# Etapa base con la imagen de ASP.NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

# Etapa de construcción con la imagen de SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos .csproj de todos los proyectos
COPY ["Test.Api/Test.Api.csproj", "Test.Api/"]
COPY ["Test.Domain/Test.Domain.csproj", "Test.Domain/"]
COPY ["Test.Persistence/Test.Persistence.csproj", "Test.Persistence/"]

# Restaurar las dependencias de Test.Api (y las dependencias de Test.Domain y Test.Persistence)
RUN dotnet restore "Test.Api/Test.Api.csproj"

# Copiar todo el código fuente del proyecto
COPY . .

# Establecer el directorio de trabajo al proyecto Test.Api antes de la compilación
WORKDIR "/src/Test.Api"

# Construir el proyecto
RUN dotnet build "Test.Api.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "Test.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final para ejecutar la API en un contenedor de producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Api.dll"]
