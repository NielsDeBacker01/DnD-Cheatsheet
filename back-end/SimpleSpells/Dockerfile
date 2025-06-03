FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
EXPOSE 5001
##Set environment as production default (set to development in docker compose if needed for testing)
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "SimpleSpells.dll"]