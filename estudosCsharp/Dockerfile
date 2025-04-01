# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# 1. Defina o WORKDIR primeiro
WORKDIR /src

# 2. Copie o .csproj usando o caminho relativo correto
COPY ["WebAppDocker/WebAppDocker.csproj", "WebAppDocker/"]

# 3. Restaure as dependências
RUN dotnet restore "WebAppDocker/WebAppDocker.csproj"

# 4. Copie o resto dos arquivos
COPY . .

# 5. Build e publish
WORKDIR "/src/WebAppDocker"
RUN dotnet publish -c Release -o /app/publish

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebAppDocker.dll"]