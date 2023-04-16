#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PipiApp/PipiApp.Api.csproj", "PipiApp/"]
COPY ["PipiApp.Data/PipiApp.Data.csproj", "PipiApp.Data/"]
COPY ["PipiApp.Model/PipiApp.Models.csproj", "PipiApp.Model/"]
COPY ["PipiApp.Repositories/PipiApp.Repositories.csproj", "PipiApp.Repositories/"]
RUN dotnet restore "PipiApp/PipiApp.Api.csproj"
COPY . .
WORKDIR "/src/PipiApp"
RUN dotnet build "PipiApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PipiApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PipiApp.Api.dll"]
