#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CSharp_Basic/CSharp_Basic.csproj", "CSharp_Basic/"]
RUN dotnet restore "CSharp_Basic/CSharp_Basic.csproj"
COPY . .
WORKDIR "/src/CSharp_Basic"
RUN dotnet build "CSharp_Basic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharp_Basic.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharp_Basic.dll"]