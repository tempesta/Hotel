#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["Hotel.Api/Hotel.Api.csproj", "Hotel.Api/"]
RUN dotnet restore "Hotel.Api/Hotel.Api.csproj"
COPY . .
WORKDIR "/src/Hotel.Api"
RUN dotnet build "Hotel.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hotel.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hotel.Api.dll"]