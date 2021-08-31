# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build

WORKDIR /app
COPY . ./
COPY Webshop/Webshop.csproj ./Webshop
RUN dotnet restore ./Webshop

WORKDIR /app/Webshop
RUN dotnet publish -c Release -o dist

FROM node:16-alpine3.11 AS buildvue
WORKDIR /Webshop
COPY web/package*.json ./
RUN npm ci

COPY web .
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/Webshop/dist .
COPY --from=buildvue Webshop/dist /app/wwwroot
CMD ["dotnet", "Webshop.dll"]


