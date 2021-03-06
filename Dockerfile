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

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
EXPOSE 8080
COPY --from=buildvue /app/dist /app/wwwroot
COPY --from=buildvue /app/public/images /app/wwwroot
COPY --from=build /app/src/Webshop/out /app
CMD ["dotnet", "Webshop.dll"]


