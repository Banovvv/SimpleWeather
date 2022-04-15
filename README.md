# SimpleWeather

## Summary
This is a <strong>C# (.NET 6)</strong> library that provides simple means of obtaining weather data from the [OpenWeatherMap's API](https://openweathermap.org/api).

## Status
[![NuGet Badge](https://buildstats.info/nuget/SimpleWeather)](https://www.nuget.org/packages/SimpleWeather)

## Upcomming features
*No upcomming features right now*

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
var weatherForecast = await weatherController.GetWeatherForecast("Lovech");

Console.WriteLine($"The current weather in {currentWeather.City} is {Math.Round(currentWeather.Main.Temperature)}°C degrees with {currentWeather.Weather.Description}.\n");

Console.WriteLine("The weather forecast for the next 7 days is:\n");

foreach (var day in weatherForecast.Daily)
{
    Console.WriteLine($"The weather for: {day.DT.ToString("dd.MM.yyyy")}");
    Console.WriteLine($"Min temperature: {Math.Round(day.Temperature.Min)}°C");
    Console.WriteLine($"Max temperature: {Math.Round(day.Temperature.Max)}°C");
    Console.WriteLine($"Wind speed will be: {day.WindSpeed} m/s");
    Console.WriteLine($"Wind direction will be: {day.WindDirectionLong} ({day.WindDirectionShort})");
    Console.WriteLine($"The weather conditions will be: {day.Weather.Description}");
    Console.WriteLine($"Probability for precipitation: {day.PrecipitationProbability}%");
    Console.WriteLine($"The moon phase will be: {day.MoonPhase}\n");
}
```
This will produce the following result:
```
The current weather in Lovech is 17°C degrees with clear sky.

The weather forecast for the next 7 days is:

The weather for: 15.04.2022
Min temperature: 9°C
Max temperature: 22°C
Wind speed will be: 2.2 m/s
Wind direction will be: South-southwest (SSW)
The weather conditions will be: clear sky
Probability for precipitation: 0%
The moon phase will be: Full Moon
.
.
.
The weather for: 21.04.2022
Min temperature: 5°C
Max temperature: 17°C
Wind speed will be: 7.63 m/s
Wind direction will be: West (W)
The weather conditions will be: few clouds
Probability for precipitation: 0%
The moon phase will be: Waning Gibbous
```

## Installation
**DISCLAIMER:** Plese note that this package is still under development and bugs may be present. If you spot a bug, please [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new)

You can install the NuGet library into your project using:

Package Manager:
```
Install-Package SimpleWeather -Version 2.5.0
```

.NET CLI:
```
dotnet add package SimpleWeather --version 2.5.0
```

## License
Copyright © 2022 Ivan Gechev.

This package has MIT license. Refer to the [LICENSE](https://github.com/Banovvv/SimpleWeather/blob/a7b24c51d62e71722899b42aded8e48fb6c8fe7e/LICENSE) for detailed information.

## Questions, comments or additions
If you have a feature request or bug report, [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new) or [send a Pull request](https://github.com/Banovvv/SimpleWeather/pulls).

## Support
If you like this project, give it a ⭐ and share it with friends!
