FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

EXPOSE 80

WORKDIR /

# copy and publish app and libraries
COPY . .

RUN dotnet restore "src/ProjectName.ModuleName.ModuleName.API/ProjectName.ModuleName.ModuleName.API.csproj"

RUN dotnet publish -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf && sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ProjectName.ModuleName.ModuleName.API.dll"]