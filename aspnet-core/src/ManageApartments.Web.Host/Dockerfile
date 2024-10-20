FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/ManageApartments.Web.Host/ManageApartments.Web.Host.csproj", "src/ManageApartments.Web.Host/"]
COPY ["src/ManageApartments.Web.Core/ManageApartments.Web.Core.csproj", "src/ManageApartments.Web.Core/"]
COPY ["src/ManageApartments.Application/ManageApartments.Application.csproj", "src/ManageApartments.Application/"]
COPY ["src/ManageApartments.Core/ManageApartments.Core.csproj", "src/ManageApartments.Core/"]
COPY ["src/ManageApartments.EntityFrameworkCore/ManageApartments.EntityFrameworkCore.csproj", "src/ManageApartments.EntityFrameworkCore/"]
WORKDIR "/src/src/ManageApartments.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ManageApartments.Web.Host", "src/ManageApartments.Web.Host"]
COPY ["src/ManageApartments.Web.Core", "src/ManageApartments.Web.Core"]
COPY ["src/ManageApartments.Application", "src/ManageApartments.Application"]
COPY ["src/ManageApartments.Core", "src/ManageApartments.Core"]
COPY ["src/ManageApartments.EntityFrameworkCore", "src/ManageApartments.EntityFrameworkCore"]
WORKDIR "/src/src/ManageApartments.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ManageApartments.Web.Host.dll"]
