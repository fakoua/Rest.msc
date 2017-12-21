FROM microsoft/dotnet-framework:4.7
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENV APIKEY 111
ENV DockerEnv true
ENTRYPOINT ["C:\\app\\Rest.msc.exe"]
