#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProCar/ProCar.csproj", "ProCar/"]
#COPY ["ProCar/node_modules/", "/app/node_modules/"]
#RUN ls -la /app/node_modules/
#COPY ["ProCar/Data/imgs/text.txt", "/app/Data/imgs/"]
#RUN ls -la /app/Data/
#COPY ["ProCar/Data/", "/app/Migrations/"]
#RUN mkdir -p /app/Data/imgs


RUN dotnet restore "ProCar/ProCar.csproj"
COPY . .
WORKDIR "/src/ProCar"
RUN dotnet build "ProCar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProCar.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN mkdir -p /app/Data/imgs
RUN mkdir -p /Data/imgs
RUN mkdir -p Data/imgs

COPY --from=publish /app/publish .



ENTRYPOINT ["dotnet", "ProCar.dll"]