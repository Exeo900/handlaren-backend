FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY . .

RUN dotnet publish -c Staging -o /app 

FROM mcr.microsoft.com/dotnet/aspnet:8.0.0-jammy-arm32v7

ENV ASPNETCORE_URLS http://+:8181
ENV ASPNETCORE_ENVIRONMENT=Staging

WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "handlaren-backend.dll"]