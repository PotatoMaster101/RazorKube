FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RazorKube/RazorKube.csproj", "RazorKube/"]
COPY ["src/RazorKube.Web/RazorKube.Web.csproj", "RazorKube.Web/"]
RUN dotnet restore "RazorKube/RazorKube.csproj"
RUN dotnet restore "RazorKube.Web/RazorKube.Web.csproj"
COPY ["src/RazorKube", "RazorKube/"]
COPY ["src/RazorKube.Web", "RazorKube.Web/"]
WORKDIR /src/RazorKube.Web
RUN dotnet build "RazorKube.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorKube.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.15 AS production
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorKube.Web.dll"]
