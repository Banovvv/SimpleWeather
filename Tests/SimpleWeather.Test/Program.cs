using SimpleWeather;

using var weatherController = new WeatherController();
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

Console.WriteLine();
