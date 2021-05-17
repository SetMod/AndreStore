#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Aggreagator/Aggreagator.csproj", "Aggreagator/"]
RUN dotnet restore "Aggreagator/Aggreagator.csproj"
COPY . .
WORKDIR "/src/Aggreagator"
RUN dotnet build "Aggreagator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aggreagator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aggreagator.dll"]