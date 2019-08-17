FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CosmosDbDemo1.csproj", ""]
RUN dotnet restore "./CosmosDbDemo1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CosmosDbDemo1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CosmosDbDemo1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CosmosDbDemo1.dll"]