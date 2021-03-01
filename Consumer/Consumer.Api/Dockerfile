FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Consumer.Api/Consumer.Api.csproj", "Consumer.Api/"]
COPY ["Consumer.Infrastructure/Consumer.Infrastructure.csproj", "Consumer.Infrastructure/"]
COPY ["Consumer.Application/Consumer.Application.csproj", "Consumer.Application/"]
COPY ["Consumer.Domain/Consumer.Domain.csproj", "Consumer.Domain/"]
RUN dotnet restore "Consumer.Api/Consumer.Api.csproj"
COPY . .
WORKDIR "/src/Consumer.Api"
RUN dotnet build "Consumer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consumer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumer.Api.dll"]