#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NLog-tester.cs/NLog-tester.cs.csproj", "NLog-tester.cs/"]
RUN dotnet restore "NLog-tester.cs/NLog-tester.cs.csproj"
COPY . .
WORKDIR "/src/NLog-tester.cs"
RUN dotnet build "NLog-tester.cs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NLog-tester.cs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NLog-tester.cs.dll"]