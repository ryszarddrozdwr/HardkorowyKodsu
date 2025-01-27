# HardkorowyKodsu

SQL Server Docker Container:

docker run --name HardkorowyKodsu -p 1833:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Z3sadnicz00rnikaStyniewi4dysk" -d chriseaton/adventureworks:latest

Open SQL Server Management Studio

Connect to the server:
localhost,1833
users: sa
pwd: see above

Execute script: startup.sql

Modify appsettings.json (or add appsettings.Development.json) see: appsettings-readme.txt

example:
"DatabaseConnection": "Data Source=localhost,1833;User ID=HardkorowyKodsuUser01;Password=----use proper password---;Trust Server Certificate=True"
"Database": "AdventureWorks"

Build and run Backend

example:
Open folder ....\HardkorowyKodsu\Backend in cmd.exe
and run: dotnet run

Build and run HardkorowyKodsuClient
