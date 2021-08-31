# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM node:16-alpine3.11 AS node_base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY --from=node_base . .

WORKDIR /Webshop
COPY ["Webshop/Webshop.csproj", "Webshop/"]
RUN dotnet restore "Webshop/Webshop.csproj"
COPY /Webshop/. .

COPY /web/package*.json ./
COPY /web/. .
run npm install
ENV NODE_ENV=production
RUN npm ci
run npm run build
RUN dotnet publish Webshop.csproj -c Release

FROM build AS publish
RUN dotnet publish Webshop.csproj -c Release -o /app/publish

FROM base AS final
EXPOSE 8080
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webshop.dll"]

