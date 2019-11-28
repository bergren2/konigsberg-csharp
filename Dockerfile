FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /app

RUN export SONAR_SCANNER_VERSION=4.2.0.1873
RUN export SONAR_SCANNER_HOME=$HOME/.sonar/sonar-scanner-$SONAR_SCANNER_VERSION-linux
RUN rm -rf $SONAR_SCANNER_HOME
RUN mkdir -p $SONAR_SCANNER_HOME
RUN curl -sSLo $HOME/.sonar/sonar-scanner.zip https://binaries.sonarsource.com/Distribution/sonar-scanner-cli/sonar-scanner-cli-$SONAR_SCANNER_VERSION-linux.zip
RUN unzip $HOME/.sonar/sonar-scanner.zip -d $HOME/.sonar/
RUN rm $HOME/.sonar/sonar-scanner.zip
RUN export PATH=$SONAR_SCANNER_HOME/bin:$PATH
RUN export SONAR_SCANNER_OPTS="-server"

COPY . .
RUN dotnet build

RUN sonar-scanner \
  -Dsonar.projectKey=bergren2_konigsberg-csharp \
  -Dsonar.organization=bergren2 \
  -Dsonar.sources=. \
  -Dsonar.host.url=https://sonarcloud.io \
  -Dsonar.login=77059c1acc3dbb1101ea6aea2614af888fce3219
