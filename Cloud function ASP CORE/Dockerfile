#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Cloud function ASP CORE/Cloud function ASP CORE.csproj", "Cloud function ASP CORE/"]
RUN dotnet restore "Cloud function ASP CORE/Cloud function ASP CORE.csproj"
COPY . .
WORKDIR "/src/Cloud function ASP CORE"
RUN dotnet build "Cloud function ASP CORE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cloud function ASP CORE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cloud function ASP CORE.dll"]