#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.API/ProjetoPiloto.Cadastro.API.csproj", "Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.API/"]
COPY ["Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Application/ProjetoPiloto.Cadastro.Application.csproj", "Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Application/"]
COPY ["Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Domain/ProjetoPiloto.Cadastro.Domain.csproj", "Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Domain/"]
COPY ["Shared/ProjetoPiloto.Shared/ProjetoPiloto.Shared.csproj", "Shared/ProjetoPiloto.Shared/"]
COPY ["Shared/ProjetoPiloto.Utils/ProjetoPiloto.Utils.csproj", "Shared/ProjetoPiloto.Utils/"]
COPY ["Shared/ProjetoPiloto.Shared.Repository/ProjetoPiloto.Shared.Repository.csproj", "Shared/ProjetoPiloto.Shared.Repository/"]
COPY ["Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Infraestrutura/ProjetoPiloto.Cadastro.Infraestrutura.csproj", "Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.Infraestrutura/"]
RUN dotnet restore "Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.API/ProjetoPiloto.Cadastro.API.csproj"
COPY . .
WORKDIR "/src/Microservices/01 - Cadastro/ProjetoPiloto.Cadastro.API"
RUN dotnet build "ProjetoPiloto.Cadastro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoPiloto.Cadastro.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoPiloto.Cadastro.API.dll"]