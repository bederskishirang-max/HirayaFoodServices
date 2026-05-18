# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy everything
COPY . ./

# Restore and publish the specific project
RUN dotnet restore HirayaFoodServices/HirayaFoodServices.csproj
RUN dotnet publish HirayaFoodServices/HirayaFoodServices.csproj -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .

# Use the correct DLL name (same as your project)
ENTRYPOINT ["dotnet", "HirayaFoodServices.dll"]
