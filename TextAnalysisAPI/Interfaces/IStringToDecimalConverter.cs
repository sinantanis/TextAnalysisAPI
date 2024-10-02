namespace TextAnalysisAPI.Interfaces;

/// <summary>
/// Defines the contract for string to decimal conversion.
/// </summary>
/// 

// DE: Interface-Segregation-Prinzip: Eine separate Schnittstelle für die String-zu-Dezimal-Konvertierung.
public interface IStringToDecimalConverter
{
    string Convert(string input);
}