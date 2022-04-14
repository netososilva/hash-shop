FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

ENV DATABASE="Database/products.json"
ENV DISCOUNT_API_DATABASE="http://localhost:50051/"
ENV BLACK_FRIDAY_DATE="04/15/2022"

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HashShop.Api.dll"]