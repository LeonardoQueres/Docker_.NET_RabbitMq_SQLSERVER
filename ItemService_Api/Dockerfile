# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ItemService_Api/ItemService_Api.csproj", "ItemService_Api/"]
COPY ["ItemService_Borders/ItemService_Borders.csproj", "ItemService_Borders/"]
COPY ["ItemService_Repositories/ItemService_Repositories.csproj", "ItemService_Repositories/"]
COPY ["ItemService_UseCases/ItemService_UseCases.csproj", "ItemService_UseCases/"]
RUN dotnet restore "./ItemService_Api/ItemService_Api.csproj"
COPY . .
WORKDIR "/src/ItemService_Api"
RUN dotnet tool install --global dotnet-ef 
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet build "./ItemService_Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ItemService_Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT dotnet ef database update --environment Development --project src/ItemService_Repositories
ENTRYPOINT ["dotnet", "ItemService_Api.dll"]