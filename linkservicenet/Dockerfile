FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_LinkDatabaseSettings__LinkCollectionName=links
ENV ASPNETCORE_LinkDatabaseSettings__DatabaseName='link-db'
# Use below for local mongodb.  Otherwise replace with connection string
ENV ASPNETCORE_LinkDatabaseSettings__ConnectionString='mongodb://host.docker.internal:27017'
COPY out/ ./
ENTRYPOINT ["dotnet", "linkservicenet.dll"]
