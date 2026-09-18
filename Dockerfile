# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copia os arquivos .csproj
COPY ["Carrinho.Compra.API/Carrinho.Compra.API.csproj", "Carrinho.Compra.API/"]
COPY ["Carrinho.Compra.Database/Carrinho.Compra.Database.csproj", "Carrinho.Compra.Database/"]
COPY ["Carrinho.Compra.Domain/Carrinho.Compra.Domain.csproj", "Carrinho.Compra.Domain/"]
COPY ["Carrinho.Compra.Repository/Carrinho.Compra.Repository.csproj", "Carrinho.Compra.Repository/"]
COPY ["Carrinho.Compra.Service/Carrinho.Compra.Service.csproj", "Carrinho.Compra.Service/"]

# Restaura os pacotes
RUN dotnet restore "Carrinho.Compra.API/Carrinho.Compra.API.csproj"

# Copia o código
COPY . .

# Compila
WORKDIR "/src/Carrinho.Compra.API"
RUN dotnet build "Carrinho.Compra.API.csproj" -c Release -o /app/build

# Publica
FROM build AS publish
RUN dotnet publish "Carrinho.Compra.API.csproj" -c Release -o /app/publish /p:UseAppHost=false


# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Carrinho.Compra.API.dll"]