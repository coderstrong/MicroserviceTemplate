FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ProjectName.Api/*.csproj ./ProjectName.Api/
COPY ProjectName.Domain/*.csproj ./ProjectName.Domain/
COPY ProjectName.Infrastructure/*.csproj ./ProjectName.Infrastructure/
COPY ProjectName.UnitTest/*.csproj ./ProjectName.UnitTest/
WORKDIR /app/ProjectName.Api
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY ProjectName.Api/. ./ProjectName.Api/
COPY ProjectName.Domain/. ./ProjectName.Domain/
COPY ProjectName.Infrastructure/. ./ProjectName.Infrastructure/
COPY ProjectName.UnitTest/. ./ProjectName.UnitTest/
WORKDIR /app/ProjectName.Api
RUN dotnet publish -c Release -o out


# test application -- see: dotnet-docker-unit-testing.md
FROM build AS testrunner
WORKDIR /app/ProjectName.UnitTest
COPY ProjectName.UnitTest/. .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf
COPY --from=build /app/ProjectName.Api/out ./
ENTRYPOINT ["dotnet", "ProjectName.Api.dll"]