# 1. Använd .NET 9.0 SDK för att bygga appen
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 2. Kopiera projektfilen och återställ (restore)
COPY ["Personnummer/Personnummer.csproj", "Personnummer/"]
RUN dotnet restore "Personnummer/Personnummer.csproj"

# 3. Kopiera resten av koden och bygg appen
COPY . .
WORKDIR "/src/Personnummer"
RUN dotnet publish "Personnummer.csproj" -c Release -o /app/publish

# 4. Skapa den slutgiltiga containern (Runtime)
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish .

# 5. Ange startpunkt
ENTRYPOINT ["dotnet", "Personnummer.dll"]