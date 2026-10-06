# -------------------------------------------------------------------
# Estagio de Compilacao (SDK .NET 10)
# -------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar arquivo de projeto e restaurar dependencias
COPY ["TutorialMatematica.csproj", "./"]
RUN dotnet restore "TutorialMatematica.csproj"

# Copiar codigo-fonte completo
COPY . .

# Publicar aplicacao em modo Release
RUN dotnet publish "TutorialMatematica.csproj" -c Release -o /app/publish /p:UseAppHost=false

# -------------------------------------------------------------------
# Estagio de Execucao (Runtime ASP.NET Core 10)
# -------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copiar binarios do estagio de build
COPY --from=build /app/publish .

# Configuracoes de ambiente
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_PRINT_TELEMETRY_MESSAGE=false

# Porta padrao (a variavel $PORT sera injetada automaticamente pela Railway)
EXPOSE 8080

ENTRYPOINT ["dotnet", "TutorialMatematica.dll"]
