FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build


ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

WORKDIR /app
COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c $BUILDCONFIG -o out


FROM mcr.microsoft.com/dotnet/core/sdk:3.1



ENV REDISHOST=172.17.0.2
ENV REDISPORT=6379

EXPOSE 5000

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "ApiRuletaOnline.dll"] 