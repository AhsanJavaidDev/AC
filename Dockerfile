# .NET Core SDK
FROM mcr.microsoft.com/dotnet/core/sdk:6.0-alpine AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY Src/AcmeCorp.Application/AcmeCorp.Application.csproj ./Src/AcmeCorp.Application/
COPY Src/AcmeCorp.Domain/AcmeCorp.Domain.csproj ./Src/AcmeCorp.Domain/
COPY Src/AcmeCorp.Domain.Core/AcmeCorp.Domain.Core.csproj ./Src/AcmeCorp.Domain.Core/
COPY Src/AcmeCorp.Infra.CrossCutting.Bus/AcmeCorp.Infra.CrossCutting.Bus.csproj ./Src/AcmeCorp.Infra.CrossCutting.Bus/
COPY Src/AcmeCorp.Infra.CrossCutting.Identity/AcmeCorp.Infra.CrossCutting.Identity.csproj ./Src/AcmeCorp.Infra.CrossCutting.Identity/
COPY Src/AcmeCorp.Infra.CrossCutting.IoC/AcmeCorp.Infra.CrossCutting.IoC.csproj ./Src/AcmeCorp.Infra.CrossCutting.IoC/
COPY Src/AcmeCorp.Infra.Data/AcmeCorp.Infra.Data.csproj ./Src/AcmeCorp.Infra.Data/
COPY Src/AcmeCorp.Services.Api/AcmeCorp.Services.Api.csproj ./Src/AcmeCorp.Services.Api/

# .NET Core Restore
RUN dotnet restore ./Src/AcmeCorp.Services.Api/AcmeCorp.Services.Api.csproj

# Copy All Files
COPY Src ./Src

# .NET Core Build and Publish
RUN dotnet publish ./Src/AcmeCorp.Services.Api/AcmeCorp.Services.Api.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:6.0-alpine AS runtime
WORKDIR /app
COPY --from=build /publish ./

# Expose ports
EXPOSE 80
EXPOSE 443

# Setup your variables before running.
ARG MyEnv
ENV ASPNETCORE_ENVIRONMENT $MyEnv

ENTRYPOINT ["dotnet", "AcmeCorp.Services.Api.dll"]
