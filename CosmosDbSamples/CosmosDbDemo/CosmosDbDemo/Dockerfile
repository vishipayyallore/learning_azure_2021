FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CosmosDbDemo/CosmosDbDemo.csproj", "CosmosDbDemo/"]
RUN dotnet restore "CosmosDbDemo/CosmosDbDemo.csproj"
COPY . .
WORKDIR "/src/CosmosDbDemo"
RUN dotnet build "CosmosDbDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CosmosDbDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CosmosDbDemo.dll"]