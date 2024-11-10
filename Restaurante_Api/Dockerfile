# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 4000
EXPOSE 4001

# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Restaurante_Api/Restaurante_Api.csproj", "Restaurante_Api/"]
COPY ["Restaurante_Borders/Restaurante_Borders.csproj", "Restaurante_Borders/"]
COPY ["Restaurante_Repositories/Restaurante_Repositories.csproj", "Restaurante_Repositories/"]
COPY ["Restaurante_UseCases/Restaurante_UseCases.csproj", "Restaurante_UseCases/"]
RUN dotnet restore "./Restaurante_Api/Restaurante_Api.csproj"
COPY . .
WORKDIR "/src/Restaurante_Api"
RUN dotnet tool install --global dotnet-ef 
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet build "./Restaurante_Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Restaurante_Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT dotnet ef database update --environment Development --project src/Restaurante_Repositories
ENTRYPOINT ["dotnet", "Restaurante_Api.dll"]