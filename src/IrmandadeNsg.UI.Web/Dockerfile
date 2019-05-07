FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/IrmandadeNsg.UI.Web/IrmandadeNsg.UI.Web.csproj", "src/IrmandadeNsg.UI.Web/"]
RUN dotnet restore "src/IrmandadeNsg.UI.Web/IrmandadeNsg.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/IrmandadeNsg.UI.Web"
RUN dotnet build "IrmandadeNsg.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IrmandadeNsg.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IrmandadeNsg.UI.Web.dll"]