FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MouseProcessing.Client/MouseProcessing.Client.csproj", "MouseProcessing.Client/"]
RUN dotnet restore "./MouseProcessing.Client/MouseProcessing.Client.csproj"
COPY . .
WORKDIR "/src/MouseProcessing.Client"
RUN dotnet build "./MouseProcessing.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MouseProcessing.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MouseProcessing.Client.dll"]