# SimpleWeather

## Summary
This is a <b>.NET</b> 6 project that provides simple means of obtaining weather data from the [OpenWeatherMap's API](https://openweathermap.org/api).

## Status
// TODO

## Methods
At this point there is only one <b>asynchronous</b> method which returns and Object containing all the data for the current weather in a given city:
```Csharp
GetCurrentWeatherResponse()
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
//TODO
```

.NET CLI:
```
//TODO
```

## License
Copyright © 2022 Ivan Gechev.

This package has MIT license. Refer to the [LICENSE](https://github.com/Banovvv/SimpleWeather/blob/a7b24c51d62e71722899b42aded8e48fb6c8fe7e/LICENSE) for detailed information.

## Questions, comments or additions
If you have a feature request or bug report, [open a new Issue](https://github.com/Banovvv/SimpleWeather/issues/new) or [send a Pull request](https://github.com/Banovvv/SimpleWeather/pulls).
