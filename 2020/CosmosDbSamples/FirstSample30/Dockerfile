FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["FirstSample30.csproj", ""]
RUN dotnet restore "./FirstSample30.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FirstSample30.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FirstSample30.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FirstSample30.dll"]