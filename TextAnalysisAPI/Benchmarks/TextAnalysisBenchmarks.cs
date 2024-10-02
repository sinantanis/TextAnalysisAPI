using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Running;
using TextAnalysisAPI.Interfaces;


namespace TextAnalysisApi.Benchmarks;
//Mit dem MemoryDiagnoser-Attribut messen wir auch den Speicherverbrauch
[MemoryDiagnoser]
public class TextAnalysisBenchmarks
{
    private readonly ITextAnalysisService _textAnalysisService;
    private readonly IStringToDecimalConverter _stringToDecimalConverter;
    
    public TextAnalysisBenchmarks()
    {
        _textAnalysisService = new TextAnalysisService();
        _stringToDecimalConverter = new StringToDecimalConverter();
    }

    // DE: Benchmark-Methoden für jede Funktionalität
    [Benchmark]
    public void CountWords() => _textAnalysisService.CountWords("This is a test string for benchmarking", new[] { "is", "test", "benchmarking" });

    [Benchmark]
    public void CheckWords() => _textAnalysisService.CheckWords("This is a test string for benchmarking", new[] { "is", "test", "benchmarking" });

    [Benchmark]
    public void CountLetters() => _textAnalysisService.CountLetters("This is a test string for benchmarking", new[] { 't', 'i', 's' });

    [Benchmark]
    public void CheckLetters() => _textAnalysisService.CheckLetters("This is a test string for benchmarking", new[] { 't', 'i', 's' });

    [Benchmark]
    public void IsBase64() => _textAnalysisService.IsBase64("VGhpcyBpcyBhIHRlc3Qgc3RyaW5n");

    [Benchmark]
    public void IsEmail() => _textAnalysisService.IsEmail("test@example.com");

    [Benchmark]
    public void ConvertToDecimal() => _stringToDecimalConverter.Convert("1,600,500.3025 m");

    [Benchmark]
    public void ConvertToDecimal_LargeNumber() => _stringToDecimalConverter.Convert("1,000,000,000,000.3025 m");

    [Benchmark]
    public void ConvertToDecimal_ManyDecimalPlaces() => _stringToDecimalConverter.Convert("1.123456789012345");

    public static void Main(string[] args) => BenchmarkRunner.Run<TextAnalysisBenchmarks>();
}