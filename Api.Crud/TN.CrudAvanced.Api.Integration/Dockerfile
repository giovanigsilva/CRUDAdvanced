
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TN.CrudAvanced.Api.Integration.csproj", "."]
RUN dotnet restore "./TN.CrudAvanced.Api.Integration.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TN.CrudAvanced.Api.Integration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.CrudAvanced.Api.Integration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.CrudAvanced.Api.Integration.dll"]