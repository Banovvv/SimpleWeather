# SimpleWeather

## Summary
This is a C# (.NET 6) library that provides simple means of obtaining weather data from the [OpenWeatherMap's API](https://openweathermap.org/api).

## Status
[![NuGet Badge](https://buildstats.info/nuget/SimpleWeather)](https://www.nuget.org/packages/SimpleWeather/1.0.0)

## Methods
At this point there is only one <b>asynchronous</b> method which returns and Object containing all the data for the current weather in a given city:
```Csharp
GetCurrentWeatherResponse(string city, string units)
```
## Prerequisites
In order for the library to work you need to have a <b>appsettings.json</b> file (containing your [OpenWeatherMap's API KEY](https://openweathermap.org/api)) in your project's output directory containing the following:
```Json
{
  "openWeatherApiKey": "YourKeyGoesHere"
}
```

## Example usage
```Csharp
using SimpleWeather;

var weatherController = new WeatherController();
var currentWeather = await weatherController.GetCurrentWeatherResponse("Lovech", "metric");


Console.WriteLine($"The current temperature in {currentWeather.City} is {currentWeather.Main.Temperature} degrees.");
```

## Installation
**DISCLAIMER:** Plese note that this package is still under development and bugs may be present. If you spot a bug, please [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new)

You can install the NuGet library into your project using:

Package Manager:
```
Install-Package SimpleWeather -Version 1.0.0
```

.NET CLI:
```
dotnet add package SimpleWeather --version 1.0.0
```

## License
Copyright © 2022 Ivan Gechev.

This package has MIT license. Refer to the [LICENSE](https://github.com/Banovvv/SimpleWeather/blob/a7b24c51d62e71722899b42aded8e48fb6c8fe7e/LICENSE) for detailed information.

## Questions, comments or additions
If you have a feature request or bug report, [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new) or [send a Pull request](https://github.com/Banovvv/SimpleWeather/pulls).
