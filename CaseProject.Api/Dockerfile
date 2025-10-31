FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CaseProject.Api/CaseProject.Api.csproj", "CaseProject.Api/"]
COPY ["CaseProject.Dal/CaseProject.Dal.csproj", "CaseProject.Dal/"]
COPY ["CaseProject.Entities/CaseProject.Entities.csproj", "CaseProject.Entities/"]
COPY ["CaseProject.Bll/CaseProject.Bll.csproj", "CaseProject.Bll/"]
RUN dotnet restore "CaseProject.Api/CaseProject.Api.csproj"
COPY . .
WORKDIR "/src/CaseProject.Api"
RUN dotnet build "CaseProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CaseProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaseProject.Api.dll"]
