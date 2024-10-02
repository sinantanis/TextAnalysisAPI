using BenchmarkDotNet.Running;
using TextAnalysisApi.Benchmarks;
using TextAnalysisAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection: Wir setzen das Dependency Inversion Prinzip aus den SOLID-Prinzipien um.
builder.Services.AddSingleton<ITextAnalysisService, TextAnalysisService>();
builder.Services.AddSingleton<IStringToDecimalConverter, StringToDecimalConverter>();

if (args.Length > 0 && args[0] == "--benchmark")
{
    TextAnalysisBenchmarks.Main(args); //Release mode
    //BenchmarkRunner.Run<TextAnalysisBenchmarks>(); //Release mode
    return;
}

var app = builder.Build();

app.MapPost("/count-words", (ITextAnalysisService service, string text, string[] words)
    => Results.Ok(service.CountWords(text, words)));

app.MapPost("/check-words", (ITextAnalysisService service, string text, string[] words)
    => Results.Ok(service.CheckWords(text, words)));

app.MapPost("/count-letters", (ITextAnalysisService service, string text, char[] letters)
    => Results.Ok(service.CountLetters(text, letters)));

app.MapPost("/check-letters", (ITextAnalysisService service, string text, char[] letters)
    => Results.Ok(service.CheckLetters(text, letters)));

app.MapPost("/is-base64", (ITextAnalysisService service, string text)
    => Results.Ok(new { IsBase64 = service.IsBase64(text) }));

app.MapPost("/is-email", (ITextAnalysisService service, string text)
    => Results.Ok(new { IsEmail = service.IsEmail(text) }));

//Bonusaufgabe: String zu Decimal Konvertierung
app.MapPost("/convert-to-decimal", (IStringToDecimalConverter converter, string text)
    => Results.Ok(new { DecimalValue = converter.Convert(text) }));

app.Run();