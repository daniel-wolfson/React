# PandoLogic Task
# React + Redux + TypeScript + .NET Core

## About this Project

A sample project combining a variety of useful web development technologies originally shown to work together React.
This app features:
- React Chars 2
- TypeScript
- Bootstrap
- Asp Net Core 3.1

## Structure of solution

- JobApi.sln is the entry point for "classic" editions of Visual Studio (Pro, Community, etc).
- JobApi/JobApi.csproj is a Web api (asp net core) project.
- JobApi.Tests/JobApi.Tests.csproj is a unit test for web api project.
- JobClient - react client

## Build and start

1. build JobClient (react client)

- cd pandologic_react_core\JobClient
- npm install
- npm run start
- client working on http://localhost:3000
- client working with web api started on http://localhost:5000

2. build JobApi.sln

2.1 build from visual studio (or visual studio code)
    - build and solution: F5, Ctrl-F5

2.2 build from visual studio code:
   - build: dotnet build .
   - for start:
        cd pandologic_react_core\JobApi\bin\Debug\netcoreapp3.1
        JobViewsApi.exe
    - app starting on http://localhost:5000

3. unit test (xUnit) api:
    - start with visual studio unit test explorer