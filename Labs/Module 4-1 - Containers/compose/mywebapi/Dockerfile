FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.3-nanoserver-1809
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 9000
ENV ASPNETCORE_URLS http://+:9000
EXPOSE 9000

ENTRYPOINT ["dotnet", "mywebapi.dll"]