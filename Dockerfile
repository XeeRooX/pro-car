#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
RUN locale-gen en_US.UTF-8
RUN update-locale LANG=en_US.UTF-8 LC_MESSAGES=POSIX


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProCar/ProCar.csproj", "ProCar/"]
RUN dotnet restore "ProCar/ProCar.csproj"
#COPY ["ProCar/node_modules/", "/app/node_modules/"]
RUN ls -la /app/node_modules/
COPY ["ProCar/Data/", "/app/Data/"]
RUN ls -la /app/Data/
COPY . .
WORKDIR "/src/ProCar"
RUN dotnet build "ProCar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProCar.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ProCar.dll"]