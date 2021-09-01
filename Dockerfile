# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build

WORKDIR /app
COPY src/Webshop/*.csproj ./src/Webshop
RUN dotnet restore ./src/Webshop

COPY . ./
WORKDIR /app/src/Webshop
RUN dotnet publish -c Release -o dist

FROM node:15-alpine AS buildvue
WORKDIR /src
COPY web/package*.json ./
RUN npm ci

COPY web .
ARG VUE_APP_PUBLIC_PATH=/
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/src/Webshop/dist .
COPY --from=buildvue /src/dist /app/wwwroot
CMD ["dotnet", "Webshop.dll"]


