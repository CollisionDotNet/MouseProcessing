FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MouseProcessing.API/MouseProcessing.API.csproj", "MouseProcessing.API/"]
RUN dotnet restore "./MouseProcessing.API/MouseProcessing.API.csproj"
COPY . .
WORKDIR "/src/MouseProcessing.API"
RUN dotnet build "./MouseProcessing.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MouseProcessing.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MouseProcessing.API.dll"]