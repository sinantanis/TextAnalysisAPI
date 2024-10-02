using System.Globalization;
using System.Text.RegularExpressions;
using TextAnalysisAPI.Interfaces;

namespace TextAnalysisApi.Services;

// DE: Single-Responsibility-Prinzip: Diese Klasse ist nur für die Konvertierung von String zu Dezimal verantwortlich
/// <summary>
/// Provides implementation for string to decimal conversion.
/// </summary>
public class StringToDecimalConverter : IStringToDecimalConverter
{
    /// <summary>
    /// Converts a string representation of a number to a decimal format.
    /// </summary>
    /// <param name="input">The input string to convert.</param>
    /// <returns>A string representation of the decimal number, or "0" if conversion fails.</returns>
    public string Convert(string input)
    {
        // DE: YAGNI-Prinzip: Wir führen nur die notwendigen Operationen durch.
        try
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty.");

            var cleanedInput = CleanInput(input); 
            var normalizedInput = NormalizeInput(cleanedInput);

            if (decimal.TryParse(normalizedInput, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out var result))
            {
                return FormatResult(result);
            }

            throw new ArgumentException("Invalid number format.");
        }
        catch (Exception ex)
        {
            // Log the exception here
            return "0"; // Or return a more descriptive error message
        }
    }

    private string CleanInput(string input)
    {
        return Regex.Replace(input, @"[m_'\s]", "");
    }

    private string NormalizeInput(string input)
    {
        var parts = input.Split(new[] { '.', ',' });
        if (parts.Length > 1)
        {
            var integerPart = string.Join("", parts.Take(parts.Length - 1)).Replace(".", "");
            var decimalPart = parts.Last();
            return integerPart + "," + decimalPart;
        }
        return input.Replace(".", "");
    }

    private string FormatResult(decimal result)
    {
        return result == Math.Floor(result)
            ? result.ToString("0", CultureInfo.GetCultureInfo("de-DE"))
            : result.ToString(CultureInfo.GetCultureInfo("de-DE"));
    }
}