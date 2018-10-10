FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 55479
EXPOSE 44302

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ../SuperApp.Api/SuperApp.Api.csproj ../SuperApp.Api/
RUN dotnet restore ../SuperApp.Api/SuperApp.Api.csproj
COPY . .
WORKDIR /src/../SuperApp.Api
RUN dotnet build SuperApp.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SuperApp.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SuperApp.Api.dll"]
