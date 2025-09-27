# WemaAnalytics Assessment

## Overview
This repo contains:
- `Chiamaka.WemaAnalytics.Api` — minimal .NET Web API with EF Core + MediatR for Branch CRUD (CQRS)
- `Chiamaka.WemaAnalytics.WorkerService` — worker service that writes KPI snapshots
- `sql/` — SQL scripts (tables, upsert stored proc, agent job)

## Prerequisites
- .NET SDK (8)
- SQL Server
- dotnet-ef tool (`dotnet tool install --global dotnet-ef`)

## Setup (API)
1. Configure connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "AppDBConnection": "Server=localhost\\SQLEXPRESS;Database=Wema_Analytic_Db;Trusted_Connection=True;TrustServerCertificate=True"
}
