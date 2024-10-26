# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY ./api.csproj ./api.csproj

RUN dotnet restore

# Copy the rest of the application code
COPY ./ ./

# Expose the port the application will run on
EXPOSE 5018

# Set the entry point for the application
CMD ["dotnet", "watch", "run", "--project" , "api.csproj",  "--urls", "http://*:5018"]