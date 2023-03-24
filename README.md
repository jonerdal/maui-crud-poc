_.NET | MAUI | Entity Framework Core | API_

## Introduction
This project is meant as a learning playground. One purpose is of course to explore .NET MAUI, but also allowing me to dig deeper into other areas. The project is in no way intended for production purposes. 

## Architecture 
Initially, it will have a backend CRUD API and a MAUI frontend Android application. In order not to have to create a NuGet package (at least not initially) for the API contract, they all reside in the same solution. 

## Design
Starting of, the design will be simple. The intent of this project is not to build a great looking application. It will start by simply being able to show and manage the entities persisted in the backend. The entities will be called locations, and are meant to represent a location on a map, however adding a map feature is far away and might very well not be implemented at all.

## Development path
- Develop a basic CRUD API with in memory storage (**ASP.NET Core web API**).
- Add persistent storage (**Entity Framework Core**).
- Create simple Android application (**.NET MAUI**).
- Cleanup backend, implement ErrorOr (**.NET**).
- Create DB migration (**Entity Framework Core**).

## Potential further development
- Add map in FE.
- Add more complex data types and restrictions on entered data, i.e. length on fields or if we have lists we need to tell EF how to store it in the DB.
- Change backend db from sqlite to Cosmos DB.
- Login and RBAC.
- NuGet for contract