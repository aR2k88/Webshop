# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 1337
EXPOSE 443

FROM node:16-alpine3.11
# install simple http server for serving static content
RUN npm install -g http-server
# make the 'app' folder the current working directory
WORKDIR /app
# copy both 'package.json' and 'package-lock.json' (if available)
COPY /web/package*.json ./
# install project dependencies
RUN npm install
# copy project files and folders to the current working directory (i.e. 'app' folder)
COPY /web/. .
# build app for production with minification
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
# Copy everything else and build
COPY . ./
WORKDIR /app/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Webshop.dll"]
