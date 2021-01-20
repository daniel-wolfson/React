# PandoLogic Task
# React + Redux + TypeScript + .NET Core

## location on github
https://github.com/daniel-wolfson/pandologic_react_core.git

## About this Project

A sample project combining a variety of useful web development technologies originally shown to work together React.
This app features:
- React with Redux and Chars
- TypeScript
- Bootstrap
- Asp Net Core 3.1

## Solution structure

- JobApi.sln is the entry point for "classic" editions of Visual Studio (Pro, Community, etc).
- JobApi/JobApi.csproj is a Web api (asp net core) project.
- JobApi.Tests/JobApi.Tests.csproj is a unit test for web api project.
- JobClient - react client

## Build and start JobClient (react client)

- cd pandologic_react_core\JobClient
- npm install
- npm run start
- client working on http://localhost:3000
- client working with web api started on http://localhost:5000

## Build and start JobApi (asp net web api)

1.1 build from visual studio (or visual studio code)
    - build and solution: F5, Ctrl-F5

1.2 build from visual studio code:
   - build: dotnet build .
   - for start:
        cd pandologic_react_core\JobApi\bin\Debug\netcoreapp3.1
        JobViewsApi.exe
    - app starting on http://localhost:5000

1.3 unit test (xUnit) api:
    - start with visual studio unit test explorer