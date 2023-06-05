#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Arbitr/Arbitr.API/Arbitr.API.csproj", "Services/Arbitr/Arbitr.API/"]
RUN dotnet restore "Services/Arbitr/Arbitr.API/Arbitr.API.csproj"
COPY . .
WORKDIR "/src/Services/Arbitr/Arbitr.API"
RUN dotnet build "Arbitr.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arbitr.API.csproj" -c Release -o /app/publish/arbitr /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/arbitr .
ENTRYPOINT ["dotnet", "Arbitr.API.dll"]