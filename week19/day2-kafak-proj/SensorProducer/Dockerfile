FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY  ["SensorProducer/SensorProducer.csproj", "SensorProducer/"]
RUN dotnet restore "SensorProducer/SensorProducer.csproj"

COPY . .

WORKDIR /src/SensorProducer
RUN dotnet publish "SensorProducer.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet" , "SensorProducer.dll"]