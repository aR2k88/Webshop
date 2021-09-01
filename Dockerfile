# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app
COPY . ./
WORKDIR /app/src/Webshop
RUN dotnet publish -c Release -o out

FROM node:15-alpine AS buildvue
WORKDIR /app
COPY web/package*.json ./
RUN npm install
COPY web .
RUN npm run build

FROM node:15-alpine as basenode

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
COPY --from=basenode . .
WORKDIR /app
EXPOSE 1337
EXPOSE 8080

COPY --from=build /app/src/Webshop/out .
COPY --from=buildvue /app /app/wwwroot
CMD ["dotnet", "Webshop.dll"]


