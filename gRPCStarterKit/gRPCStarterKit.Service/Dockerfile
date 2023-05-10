FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["gRPCStarterKit.Service.csproj", "gRPCStarterKit.Service/"]
RUN dotnet restore "gRPCStarterKit.Service/gRPCStarterKit.Service.csproj"
WORKDIR "/src/gRPCStarterKit.Service"
COPY . .
RUN dotnet build "gRPCStarterKit.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gRPCStarterKit.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gRPCStarterKit.Service.dll"]
