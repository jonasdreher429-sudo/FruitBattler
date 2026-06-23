# Pflichtenheft – FruitBattler

## 1. Softwarevoraussetzungen mit Versionen

| Software/Bilbiothek | Version |
|---|---|
| .NET | 4.8 |
| WPF (Windows Presentation Foundation) | .NET 4.8 |
| C# | 4.14.0 (C#-Tools) |
| Serilog | 4.3.1 |
| Serilog.Sinks.Console | 6.1.1 |
| Serilog.Sinks.File | 7.0.0 |
| Visual Studio | 2022 17.14.20 |
| Windows | 10 / 11 |

## 2. Architektur & Funktionsblöcke

### Projektstruktur

```
FruitBattlerWPF
  Classes
    Fruit.cs            – Frucht mit Stats, Typ und Moveset
    FruitTeam.cs        – Team aus 4 Früchten
    FruitGenerator.cs   – Erstellt alle 12 Früchte
    Move.cs             – Move mit Name, Typ, Schaden und Düngerkost
    GameHandler.cs      – Spiellogik und Rundenverwaltung
    EnemyKI.cs          – Gegner KI
    TypeEffective.cs    – Typechart
    DuengerCycle.cs     – Düngerzyklus
    Save_load.cs        – Team speichern und laden
    Logger.cs           – Logging
  Pages_window
    GameWindow.xaml         – Kampfbildschirm
    TeamBuilderWindow.xaml  – Team auswählen
  MainWindow.xaml   – Hauptmenü
  Type.cs           – Enum mit allen 13 Typen
```
### Zusammenspiel der Klassen

- **MainWindow** öffnet das **TeamBuilderWindow** und übernimmt das fertige Team
- **GameWindow** nutzt **GameHandler** für die gesamte Spiellogik
- **GameHandler** verwaltet beide Teams, den Dunger, die Rundenzahl und prüft ob das Spiel vorbei ist
- **EnemyKI** bekommt das Spielerteam und wählt anhand von **TypeEffective** den besten Move
- **Logger** wird in allen Klassen statisch aufgerufen um zu loggen


## 3. Detaillierte Umsetzungsbeschreibung

### 3.1 Schadensformel

Die Schadensberechnung in **Fruit.ReceiveDamage** funktioniert folgendermaßen:

> Schaden = (Angriff des Angreifers / Verteidigung des Verteidigers) *  > Schadenswert des Moves
> Minimum: 1 Schaden

### 3.2 Düngersystem

Der Dünger steigt pro Runde nach einer fest definierten Sequenz an:

> 1, 2, 3, 4, 5, 2, 3, 4, 5, 3, 4, 5, 4, 5 – danach immer 5


Beide Spieler (Spieler und KI) erhalten pro Runde denselben Düngerwert. Moves kosten Dünger – reicht der Dünger nicht, kann der Move nicht eingesetzt werden.

### 3.3 Typechart

Die Typeffektivität wird in **TypeEffective.cs** über ein Dictionary umgesetzt:

| Rückgabewert | Bedeutung |
|---|---|
| 1 | Sehr effektiv |
| 0 | Neutral |
| -1 | Nicht effektiv |
| -2 | Immun |

### 3.4 KI-Logik

Die KI in **EnemyKI.ChooseMove** geht das Moveset der aktiven Frucht durch und wählt den Move mit der besten Typeffektivität gegen die aktive Spielerfrucht. Kann kein Move eingesetzt werden wegen z.B. zu wenig Dpnger, fällt die KI auf Sleep zurück.

### 3.5 Automatischer Fruchtwechsel

Stirbt eine Frucht des Gegners, wird in **FruitTeam.SwitchToNextAliveFruit** automatisch die nächste lebende Frucht gesucht und als aktiv gesetzt.

### 3.6 Speichern & Laden

Das Team wird in **Save_load.cs** als JSON in eine **.txt** Datei serialisiert. Da UserControlObjekte werden beim Laden automatisch anhand des Fruchtnamens aus der **allfruits-Liste** wieder zugewiesen.

### 3.7 Team klonen

Beim Spielstart wird das Team des Spielers geklont (**MainWindow.CloneTeam**), damit nach dem Kampf die originalen Früchte unverändert bleiben und das Spiel erneut gestartet werden kann ohne das Team neu auszuwählen zu msüssen.

### 3.8 Logging

Alle relevanten Ereignisse werden über die statische **Logger**-Klasse geloggt. Serilog schreibt gleichzeitig in die Konsole und in eine tägliche Logdatei im log Ordner. Dateien werden 7 Tage aufbewahrt.

## 4. Probleme & Lösungen

- Ein großes Problem war das die Gegner ziemlich lang immer den falschen Move gewählt haben zuerst dachten wir das sie irgendwie zu stark sind aber es war der Fehler das sie egal wieviel Dünger sie haben immer denn starken Move wählten durch einen Fehler im Code. 

- Unsere wechsel Button gingen eine Zeit lang nicht bis wir herusgefunden haben das unsere UserControls zu groß waren und nicht durchklickbar waren und so über den Buttons gelegen sind.
  
- Hatten Probleme beim Speichern und beim Laden da die UserControls nicht mitspeicher bar waren dies haben wir dann mit einem JSonIgnore gefixt.