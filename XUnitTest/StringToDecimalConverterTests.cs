using Xunit;
using TextAnalysisApi.Services;
using System.Globalization;
using TextAnalysisAPI.Interfaces;

namespace TextAnalysisApi.Tests
{
    public class StringToDecimalConverterTests
    {
        private readonly IStringToDecimalConverter _converter;

        public StringToDecimalConverterTests()
        {
            _converter = new StringToDecimalConverter();
        }

        // DE: Tests für die String-zu-Dezimal-Konvertierung
        [Theory]
        [InlineData("1500,3025", "1500,3025")]
        [InlineData("1500.3025", "1500,3025")]
        [InlineData("1500,00302500", "1500,00302500")]
        [InlineData("1,500.3025", "1500,3025")]
        [InlineData("1.500 .3025", "1500,3025")]
        [InlineData("1,600,500.3025", "1600500,3025")]
        [InlineData("1.600,500.3025", "1600500,3025")]
        [InlineData("1,6.00,500.3025", "1600500,3025")]
        [InlineData("1,6.00 .500 .3025", "1600500,3025")]
        [InlineData("1_6_00_500_3025", "16005003025")]
        [InlineData("1_6_00_500.3025", "1600500,3025")]
        [InlineData("1_6_00_500_3025.01", "16005003025,01")]
        [InlineData("1_6_00_500.3025 .01", "16005003025,01")]
        [InlineData("1,6.00,500.3025 m", "1600500,3025")]
        [InlineData("1,6.00 .500 .3025 m", "1600500,3025")]
        [InlineData("f1.600,500.3025", "0")]
        [InlineData("1.0", "1")]
        [InlineData("1", "1")]
        public void Convert_ShouldReturnCorrectResult(string input, string expected)
        {
            var result = _converter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1500,3025")]
        [InlineData("1500,00302500")]
        [InlineData("1600500,3025")]
        [InlineData("16005003025")]
        [InlineData("16005003025,01")]
        [InlineData("1")]
        public void Convert_ResultShouldBeDirectlyParsableByDecimalParse(string input)
        {
            var result = _converter.Convert(input);

            // Wir versuchen, das Ergebnis mit Decimal.Parse zu parsen.
            Assert.True(decimal.TryParse(result, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out var parsedDecimal));

            // Den geparsten Wert vergleichen wir mit der ursprünglichen String-Darstellung.
            Assert.Equal(result, parsedDecimal.ToString(CultureInfo.GetCultureInfo("de-DE")));
        }
    }
}