# SimpleWeather

## Summary
This is a <strong>C# (.NET 6)</strong> library that provides simple means of obtaining weather data from the [OpenWeatherMap's API](https://openweathermap.org/api).

## Status
[![NuGet Badge](https://buildstats.info/nuget/SimpleWeather)](https://www.nuget.org/packages/SimpleWeather)

## Methods
There are two <strong>asynchronous</strong> methods which return an Object containing all the weather data for a given city:
Current weather data:
```Csharp
GetCurrentWeather(string city, string units)
```
Weather forecast data:
```Csharp
GetWeatherForecast(string city, string units)
GetWeatherForecast(double lat, double lon, string units)
```
## Prerequisites
In order for the library to work you need to have an <strong>appsettings.json</strong> file containing your [OpenWeatherMap's API KEY](https://openweathermap.org/api) in your project's output directory with the following parameter:
```Json
{
  "openWeatherApiKey": "YourKeyGoesHere"
}
```

## Example usage
```Csharp
using SimpleWeather;

var weatherController = new WeatherController();
var currentWeather = await weatherController.GetCurrentWeather("Lovech", "metric");
var weatherForecast = await weatherController.GetWeatherForecast(43.1333, 24.7167);

Console.WriteLine($"The current weather in {currentWeather.City} is {currentWeather.Main.Temperature} degrees with {currentWeather.Weather.Description}.");

Console.WriteLine("The weather forecast for Lovech for the next 7 days is:");

foreach (var day in weatherForecast.Daily)
{
    Console.WriteLine($"The weather for: {day.DT.ToString("d")}");
    Console.WriteLine($"Min temperature: {day.Temperature.Min}");
    Console.WriteLine($"Max temperature: {day.Temperature.Max}");
    Console.WriteLine($"The weather conditions will be: {day.Weather.Description}");
    Console.WriteLine($"Probability for precipitation: {day.PrecipitationProbability}%");
}
```
This will produce the following result:
```
The current weather in Lovech is 11.43 degrees with overcast clouds.

The weather forecast for the next 7 days is:

The weather for: 02.04.2022
Min temperature: 7.03
Max temperature: 20.52
The weather conditions will be: heavy intensity rain
Probability for precipitation: 100%
.
.
.
The weather for: 07.04.2022
Min temperature: 9.34
Max temperature: 17.91
The weather conditions will be: moderate rain
Probability for precipitation: 95%
```

## Installation
**DISCLAIMER:** Plese note that this package is still under development and bugs may be present. If you spot a bug, please [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new)

You can install the NuGet library into your project using:

Package Manager:
```
Install-Package SimpleWeather -Version 2.0.0
```

.NET CLI:
```
dotnet add package SimpleWeather --version 2.0.0
```

## License
Copyright © 2022 Ivan Gechev.

This package has MIT license. Refer to the [LICENSE](https://github.com/Banovvv/SimpleWeather/blob/a7b24c51d62e71722899b42aded8e48fb6c8fe7e/LICENSE) for detailed information.

## Questions, comments or additions
If you have a feature request or bug report, [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new) or [send a Pull request](https://github.com/Banovvv/SimpleWeather/pulls).
