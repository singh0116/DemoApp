FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services.Api/Services.Api.csproj", "Services.Api/"]
COPY ["Services.Application/Services.Application.csproj", "Services.Application/"]
COPY ["Services.Domain/Services.Domain.csproj", "Services.Domain/"]
COPY ["Services.Infrastructure/Services.Infrastructure.csproj", "Services.Infrastructure/"]
RUN dotnet restore "Services.Api/Services.Api.csproj"
COPY . .
WORKDIR "/src/Services.Api"
RUN dotnet build "Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Api.dll"]