namespace TextAnalysisAPI.Interfaces;
// DE: Interface-Segregation-Prinzip: Wir haben verwandte Methoden in einer einzigen Schnittstelle zusammengefasst.
/// <summary>
/// Defines the contract for text analysis operations.
/// </summary>
public interface ITextAnalysisService
{
    Dictionary<string, int> CountWords(string text, string[] words);
    Dictionary<string, bool> CheckWords(string text, string[] words);
    Dictionary<char, int> CountLetters(string text, char[] letters);
    Dictionary<char, bool> CheckLetters(string text, char[] letters);
    bool IsBase64(string text);
    bool IsEmail(string text);
}