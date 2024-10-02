using System.Text.RegularExpressions;
using TextAnalysisAPI.Interfaces;

namespace TextAnalysisApi.Services;
// DE: Single-Responsibility-Prinzip: Diese Klasse ist nur für Textanalyseoperationen verantwortlich.

/// <summary>
/// Provides implementation for text analysis operations.
/// </summary>
public class TextAnalysisService : ITextAnalysisService
{
    // DE: KISS-Prinzip: Wir verwenden eine einfache und verständliche Implementierung.
    /// <summary>
    /// Counts occurrences of specified words in the given text.
    /// </summary>
    public Dictionary<string, int> CountWords(string text, string[] words)
    {
        if (string.IsNullOrWhiteSpace(text) || words == null || words.Length == 0)
            throw new ArgumentException("Invalid input parameters.");

        var wordArray = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.ToDictionary(w => w, w => wordArray.Count(t => t.Equals(w, StringComparison.OrdinalIgnoreCase)));
    }

    /// <summary>
    /// Checks presence of specified words in the given text.
    /// </summary>
    public Dictionary<string, bool> CheckWords(string text, string[] words)
    {
        if (string.IsNullOrWhiteSpace(text) || words == null || words.Length == 0)
            throw new ArgumentException("Invalid input parameters.");

        var wordSet = new HashSet<string>(text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries), StringComparer.OrdinalIgnoreCase);
        return words.ToDictionary(w => w, w => wordSet.Contains(w));
    }
    // DE: Wir verwenden LINQ, um den Code lesbarer und kürzer zu machen.

    /// <summary>
    /// Counts occurrences of specified letters in the given text.
    /// </summary>
    public Dictionary<char, int> CountLetters(string text, char[] letters)
    {
        if (string.IsNullOrWhiteSpace(text) || letters == null || letters.Length == 0)
            throw new ArgumentException("Invalid input parameters.");

        return letters.ToDictionary(l => l, l => text.Count(c => char.ToLower(c) == char.ToLower(l)));
    }

    /// <summary>
    /// Checks presence of specified letters in the given text.
    /// </summary>
    public Dictionary<char, bool> CheckLetters(string text, char[] letters)
    {
        if (string.IsNullOrWhiteSpace(text) || letters == null || letters.Length == 0)
            throw new ArgumentException("Invalid input parameters.");

        return letters.ToDictionary(l => l, l => text.ToLower().Contains(char.ToLower(l)));
    }

    // DE: Wir verwenden Regex für die Base64-Überprüfung.
    /// <summary>
    /// Checks if the given text is a valid Base64 string.
    /// </summary>
    public bool IsBase64(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return (text.Length % 4 == 0) && Regex.IsMatch(text, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
    }

    // DE: Wir verwenden einen einfachen Regex für die E-Mail-Validierung.
    /// <summary>
    /// Checks if the given text is a valid email address.
    /// </summary>
    public bool IsEmail(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }
}