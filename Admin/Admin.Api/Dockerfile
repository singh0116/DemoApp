FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Admin.Api/Admin.Api.csproj", "Admin.Api/"]
COPY ["Admin.Infrastructure/Admin.Infrastructure.csproj", "Admin.Infrastructure/"]
COPY ["Admin.Application/Admin.Application.csproj", "Admin.Application/"]
COPY ["Admin.Domain/Admin.Domain.csproj", "Admin.Domain/"]
RUN dotnet restore "Admin.Api/Admin.Api.csproj"
COPY . .
WORKDIR "/src/Admin.Api"
RUN dotnet build "Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.Api.dll"]