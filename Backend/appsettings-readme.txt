Settings files added to .gitignore - all sensitive data
has to be invisible.

{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log.txt",
          "rollingInterval": "Day"
        }
      }
    ],
    "Enrich": [ "FromLogContext" ]
  },
  "ConnectionStrings": {
    "DatabaseConnection": "-- your connection string goes here --"
  },
  "Database": "-- your database name goes here --"
}
