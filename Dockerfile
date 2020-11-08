FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
ARG PROJECT
ARG TARGETDIR
WORKDIR /app
COPY ${TARGETDIR} .
RUN echo "#!/bin/bash \n dotnet ${PROJECT}.dll --urls http://*:80" > start.sh && chmod +x ./start.sh
ENTRYPOINT ["./start.sh"]