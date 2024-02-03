# Usar la imagen de SDK para construir el código
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copiar los archivos .cs y .csproj del proyecto al contenedor
COPY *.cs ./
COPY *.csproj ./

RUN dotnet restore

# Construir la aplicación
RUN dotnet publish -c Release -o out

# Generar la imagen de runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Cambiar el ENTRYPOINT para usar dotnet watch
# ENTRYPOINT ["dotnet", "watch", "run"]
ENTRYPOINT ["dotnet", "run"]