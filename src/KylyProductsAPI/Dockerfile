# Dockerfile para ASP.NET Core API

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["KylyProductsAPI.csproj", ""]
RUN dotnet restore "KylyProductsAPI.csproj"

COPY . .
RUN dotnet build "KylyProductsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KylyProductsAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "KylyProductsAPI.dll"]
