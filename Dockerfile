FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /app

# Install SonarScanner
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN apt-get update -qq && apt-get install -qq -y default-jre
RUN dotnet tool install --global dotnet-sonarscanner --version 4.5.0

ARG PR_BASE
ARG PR_BRANCH
ARG PR_ID
ARG SONAR_HOST=https://sonarcloud.io
ARG SONAR_ORG=bergren2
ARG SONAR_PROJECT=bergren2_konigsberg-csharp
ARG SONAR_TOKEN

COPY . .
RUN dotnet build
