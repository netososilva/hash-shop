#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DATABASE="Database/products.json"
ENV DISCOUNT_API_DATABASE="http://localhost:50051/"
ENV BLACK_FRIDAY_DATE="04/15/2022" # MM/DD/YYYY

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HashShop.Api/HashShop.Api.csproj", "HashShop.Api/"]
RUN dotnet restore "HashShop.Api/HashShop.Api.csproj"
COPY . .
WORKDIR "/src/HashShop.Api"
RUN dotnet build "HashShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HashShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HashShop.Api.dll"]