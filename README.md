# How to run

## 1. Task 1
- Open the solution `SPH.sln` in `{source}\src\netcore\server`.
- Change the connection string at 2 files: 
-- Db-Migration: `SPH.Entity\Contexts\SPHContextFactory.cs`.
-- Api: `SPH.Api\appsettings.Development.json`.
- Set the project `SPH.Api` as the _**Startup project**_.
- Open _**Package Console Manager**_ and choose the project `SPH.Entity` as default.
- Run the command `Update-Database` to apply the migration.
- Run the project.

## 2. Task 2
- Open the folder in the terminal `{source}\src\netcore\client\sph-app`.
- Run the command `npm install`.
- Open the file `webpack.config.js` and change the `apiUrl` from the **Task 1**.
- Run the command `npm start` to start the website.

## 3. Task 3
- Open the solution `SPH.HoaHC.sln` in `{source}\src\abpio`.
- Change the connection string at 2 files: 
-- `SPH.HoaHC.DbMigrator\appsettings.json`.
-- `SPH.HoaHC.Web\appsettings.json`.
- Set the project `SPH.HoaHC.Web` as the _**Startup project**_.
- Open _**Package Console Manager**_ and choose the project `SPH.HoaHC.EntityFrameworkCore.DbMigrations` as default.
- Run the command `Update-Database` to apply the migration.
- Run the project.
