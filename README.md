Projektname: Web API für Textanalyse
Beschreibung: Entwickeln Sie eine Microservice-Web-API im ASP.NET Core
Minimal API-Ansatz, die folgende Funktionen abdeckt:
1. Zählen von einem oder mehreren Wörtern in einem String.
2. Überprüfen, ob ein oder mehrere Wörter in einem String enthalten ist/sind.
3. Zählen von einem oder mehreren Buchstaben in einem String.
4. Überprüfen, ob ein oder mehrere Buchstaben in einem String enthalten
ist/sind.
5. Überprüfen, ob ein String Base64-kodiert ist.
6. Überprüfen, ob ein String eine valide E-Mail Adresse ist
Anforderungen:

1. Implementierung als Microservice mit dem ASP.NET Core Minimal API-
Ansatz, unter Berücksichtigung der Prinzipien von SOLID, DRY, YAGNI und

KISS in .NET 8.
2. Clean Code.
3. Verzicht auf die Notwendigkeit einer Datenspeicherung.
4. Keine Integration externer Systeme oder APIs.
5. Keine spezifischen Sicherheitsanforderungen.
6. Effiziente Speichernutzung.
7. Keine kommerziellen NuGets
8. Verzicht auf Swagger.
9. Entwicklung einer reinen Web-API ohne Benutzeroberfläche.
10.Inkludierung von Unit-Tests.
Lieferbarkeiten:
1. Quellcode des Projekts, der in einem öffentlichen/privaten Repository wie
GitHub gehostet wird.
2. Kurze Anleitung zur Ausführung und Testen des Projekts.

BONUS Aufgabe(n):
1. Benchmarks
2. String zu Dezimal Konvertierung
Es wird erwartet, dass die API nach Eingabe eines Strings, versucht diesen in einen
veritablen Dezimal Wert zu konvertieren. (Das eine Web API nur Daten in Form eines
Strings zurück geben kann spielt keine Rolle – Der zurückgegebene Wert muss aber
mittels Decimal.Parse(...) direkt konvertierbar sein.)
In dem Szenario können unterschiedlich schlecht formatierte Strings übergeben werden,
welche aber bis zu einem gewissen Grad dennoch konvertiert werden sollen.
Zeichen, welche vorkommen können aber nicht zu einem Abbruch führen sollen sind wie
folgt -> „ “, „m“, „_“, „‘“ (Space, Buchstabe m, Unterstrich, Apostrophe)
Siehe nächste Seite für Referenz-Konvertierungen.

EINGABE = AUSGABE

1500,3025 = 1500,3025
1500.3025 = 1500,3025
1500, 3025 = 1500,3025
1500. 3025 = 1500,3025
1500,00302500 = 1500,00302500
1500.00302500 = 1500,00302500
1,500.3025 = 1500,3025
1.500.3025 = 1500,3025
1,600,500.3025 = 1600500,3025
1.600,500.3025 = 1600500,3025
1,6.00,500.3025 = 1600500,3025
1,6.00.500.3025 = 1600500,3025
1_6_00_500_3025 = 16005003025
1_6_00_500.3025 = 1600500,3025
1_6_00_500_3025.01 = 16005003025,01
1_6_00_500.3025.01 = 16005003025,01
1,6.00,500.3025m = 1600500,3025
1,6.00.500.3025m = 1600500,3025
f1,600,500.3025 = 0
f1.600,500.3025 = 0
