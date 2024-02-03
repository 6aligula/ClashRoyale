# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar csproj y restaurar las dependencias
COPY ./*.sln ./
COPY ./P1ClashOfRoyale/*.csproj ./P1ClashOfRoyale/
RUN dotnet restore

# Copiar el resto de los archivos y construir
COPY . ./

# No se necesita ENTRYPOINT para desarrollo; se usará docker-compose.yml
