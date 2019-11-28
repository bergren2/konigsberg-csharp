FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /app

# Install SonarScanner
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN apt-get update -qq && apt-get install -qq -y default-jre
RUN dotnet tool install --global dotnet-sonarscanner --version 4.8.0

COPY . .
RUN dotnet build
