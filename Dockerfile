FROM mcr.microsoft.com/dotnet/sdk:8.0 as builder
WORKDIR /src
COPY . .
RUN dotnet publish hostbeat-web.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENTRYPOINT [ "dotnet", "HostbeatWeb.dll"]
ENV ASPNETCORE_HTTP_PORTS=80

COPY --from=builder /out/ .

EXPOSE 80
EXPOSE 443