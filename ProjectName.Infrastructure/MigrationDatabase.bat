dotnet ef migrations add InitialCreateProfile --context ProfileContext --output-dir Migrations
dotnet ef migrations add InitialCreateReport --context ReportContext --output-dir Migrations

pause;