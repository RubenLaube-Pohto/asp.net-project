FROM microsoft/aspnetcore:1.0.1
WORKDIR /app
COPY bin/release/netcoreapp1.0/publish /app
ENTRYPOINT ["dotnet", "SimpleChatProject.dll"]
