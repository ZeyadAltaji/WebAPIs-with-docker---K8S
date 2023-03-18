# Use the official .NET Core SDK image as a build image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Set the working directory to /app
WORKDIR /app

# Copy the csproj file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

# Set the working directory to /app
WORKDIR /app

# Copy the published output from the build image to the runtime image
COPY --from=build-env /app/out .

# Start the application
ENTRYPOINT ["dotnet", "PlatformService.dll"]