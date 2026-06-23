# Lastenheft – FruitBattler

## 1. Projektübersicht

**Projektname:** FruitBattler  
**Genutzte Technologien:** C# / WPF
**Entwickler:** Jonas Dreher und Marko Dvorancic

FruitBattler ist ein rundenbasiertes Kampfspiel inspiriert von Pokémon Battlern. Der Spieler stellt ein Team aus 4 Früchten zusammen und kämpft gegen ein vom Computer gesteuertes gegnerisches Team aus 4 Früchten. Jede Frucht hat individuelle Stats, einen Typ und ein Moveset.


## 2. Zielbestimmung

Das Ziel des Projekts ist die Entwicklung eines funktionsfähigen rundenbasierten Kampfspiels mit grafischer Benutzeroberfläche. Der Spieler soll ein eigenes Team zusammenstellen, speichern und laden können, und anschließend gegen eine KI antreten.


## 3. Funktionale Anforderungen

### 3.1 Hauptmenü
- Der Spieler sieht beim Start ein Hauptmenü mit den Buttons Start, TeamBuilder und Exit
- Über Start wird ein Kampf gestartet
- Über TeamBuilder kann das Team zusammengestellt werden
- Über Exit wird das Programm beendet

### 3.2 TeamBuilder
- Der Spieler kann aus 12 verschiedenen Früchten wählen
- Es können genau 4 Früchte ins Team aufgenommen werden
- Keine Frucht darf doppelt im Team vorkommen
- Das Team kann gespeichert und geladen werden (json in .txt Datei)
- Geladene Teams werden automatisch mit den passenden UserControls repariert

### 3.3 Früchte
- Es gibt 12 verschiedene Früchte, jede mit einem eigenen Typ
- Jede Frucht hat eigen Stats: HP, Angriff,Verteidigung,Geschwindigkeit
- Jede Frucht hat ein Moveset aus 3 Moves: Sleep (kostenlos), ein starker Move, ein schwächerer Move
- Früchte können Schaden erhalten und sterben wenn HP auf 0 fällt

### 3.4 Typen
Es gibt 13 Typen mit einem Typechart:
Normal, Feuer, Wasser, Elektro, Pflanze, Eis, Erde, Flug, Psycho, Gift, Gestein, Unlicht, Licht

- Typen können sehr effektiv (x1.5 Schaden), nicht effektiv oder immun sein
- STAB oder Same Type Attack Bonus: Nutzt eine Frucht einen Move des eigenen Typs, erhält der Angriff einen Bonus von 1.5x

### 3.5 Kampfsystem
- Der Kampf ist rundenbasiert
- Spieler und KI wählen pro Runde je einen Move
- Moves kosten Dünger was ein Ressourcensystem ist das pro Runde ansteigt
- Der Düngerzyklus folgt einer festen Sequenz: 1,2,3,4,5,2,3,4,5,3,4,5,4,5 (danach immer 5 Dünger/Runde)
- Sleep kostet keinen Dünger und macht keinen Schaden
- Stirbt eine Frucht des Gegners dann wird automatisch die nächste lebende Frucht eingewechselt
- Das Spiel endet wenn alle Früchte eines Teams besiegt sind

### 3.6 Schadensberechnung
Wurde mit AI gemacht, da die Formel zu erstellen für uns zu schwer gewesen wäre

Schaden = (Angriff des Angreifers / Verteidigung des Verteidigers) * Schadenswert des Moves
STAB: Schaden * 1.5 wenn Fruchttyp == Movetyp
Minimum: 1 Schaden

### 3.7 Gegner-KI
- Die KI erstellt automatisch ein zufälliges Team aus 4 unterschiedlichen Früchten
- Die KI wählt Moves anhand der Typeffektivität gegen die aktive Spielerfrucht
- Bei zu wenig Dünger fällt die KI auf Sleep zurück

### 3.8 Logging
- Das Spiel loggt alle relevanten Ereignisse via Serilog
- Logs werden in die Konsole und in eine tägliche Logdatei geschrieben
- Logdateien werden 7 Tage aufbewahrt


## 4. Produktdaten

| Eigenschaft | Wert |
|---|---|
| Anzahl Früchte | 12 |
| Teamgröße | 4 |
| Anzahl Typen | 13 |
| Moves pro Frucht | 3 |
| Düngerzyklus | fest definierte sequenz |
| Logaufbewahrung | 7 Tage |

## 5. Systemvoraussetzungen

- Windows 10 oder höher
- .NET 6 oder höher
- WPF-fähiges System


