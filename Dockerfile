# Use the .NET 8 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Use the .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GPS_Tracker_Demo.csproj", "."]
RUN dotnet restore "GPS_Tracker_Demo.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "GPS_Tracker_Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GPS_Tracker_Demo.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GPS_Tracker_Demo.dll"] 