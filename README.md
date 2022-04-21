# API Async Tests - api-sync-x-async
.NET Core based Web API, wich one represent an Application whose goal is test benefits from async API in comparison on sync API

## Prerequisites
* [.Net Core 3.1 version](https://dotnet.microsoft.com/download/dotnet/3.1)
* [Visual Studio 2019 (v16.7 or Higher)](https://visualstudio.microsoft.com/pt-br/downloads/)

## To build the API
Run this at the project folder
```
dotnet build -c Release
```

## To run the API locally
```
dotnet run
```

Voilà, the API is running now.
A message log will be displayed on CLI between intervals 0.5s, wich one has details about threads in use .
I've created a couple of endpoints each one builded on sync and async method.
To test them you can use JMeter, if you struggle on creating a Test Plan on JMeter check out the JMeter file avaiable in this project.
After set up your environment, you could use JMeter as you wish and straighfoward your requests.

## Learn More
You can learn more in the [Create API Documentation](https://docs.microsoft.com/pt-br/visualstudio/get-started/csharp/tutorial-console?view=vs-2022)

To learn C#, check out the [C# Documentation](https://docs.microsoft.com/pt-br/dotnet/csharp/)