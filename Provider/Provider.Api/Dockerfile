FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Provider.Api/Provider.Api.csproj", "Provider.Api/"]
COPY ["Provider.Application/Provider.Application.csproj", "Provider.Application/"]
COPY ["Provider.Domain/Provider.Domain.csproj", "Provider.Domain/"]
COPY ["Provider.Infrastructure/Provider.Infrastructure.csproj", "Provider.Infrastructure/"]
RUN dotnet restore "Provider.Api/Provider.Api.csproj"
COPY . .
WORKDIR "/src/Provider.Api"
RUN dotnet build "Provider.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Provider.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Provider.Api.dll"]