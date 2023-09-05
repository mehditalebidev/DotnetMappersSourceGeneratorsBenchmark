FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleObjectMapping/SimpleObjectMapping.csproj", "SimpleObjectMapping/"]
RUN dotnet restore "SimpleObjectMapping/SimpleObjectMapping.csproj"
COPY . .
WORKDIR "/src/SimpleObjectMapping"
RUN dotnet build "SimpleObjectMapping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleObjectMapping.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleObjectMapping.dll"]
