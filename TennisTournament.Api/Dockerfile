#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TennisTournament.Api/TennisTournament.Api.csproj", "TennisTournament.Api/"]
RUN dotnet restore "TennisTournament.Api/TennisTournament.Api.csproj"
COPY . .
WORKDIR "/src/TennisTournament.Api"
RUN dotnet build "TennisTournament.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TennisTournament.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TennisTournament.Api.dll"]