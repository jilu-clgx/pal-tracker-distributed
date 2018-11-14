SET DISABLE_AUTH=True
start dotnet run --urls "http://*:8881" --project Applications/AllocationsServer
start dotnet run --urls "http://*:8882" --project Applications/BacklogServer
start dotnet run --urls "http://*:8883" --project Applications/RegistrationServer
start dotnet run --urls "http://*:8884" --project Applications/TimesheetsServer