# Lastenheft / Projektidee

# Fruit Battler
## von Jonas und Marko

Wir planen ein Spiel in WPF zu programmieren, in welchem man mit seinem 4er Team von Früchten in jeweiligen 1v1s gegen das 4er Team an Früchten des Gegner Bots kämpft. Nach dem Tod einer Frucht kann man eine andere in den Kampf senden.
Das Spiel soll ein Turn Based Game sein, mit Früchten welche verschiedene Fruchttypen haben welche gegen andere Typen stärker oder schwächer sind, Attacken mit verschiedenen Kosten, und einem Team Builder in welchem man sein Team aus Früchten fabrizieren kann.


<!--
Source - https://stackoverflow.com/a/14747656
Posted by Tieme, modified by community. See post 'Timeline' for change history
Retrieved 2026-05-08, License - CC BY-SA 4.0
-->

<img src="TypeChart.png" alt="TypeChart" width="300" height="300"/>



## Must Haves
- 12 Früchte mit jeweiligem Typen, HP, DMG
  - Pyronana (Banane, Feuer)
  - Aquabeere (Blaubeere, Wasser)
  - Voltimette (Limette, Elektro)
  - Florapfel (Apfel, Pflanze)
  - Frostube (Trabue, Eis)
  - Terrango (Mango, Erde)
  - Windpfirsich (Pfirsich, Flug)
  - Mystikokos (Kokosnuss, Psycho)
  - Toxibirne (Birne, Gift)
  - Knacknuss (Walnuss, Gestein)
  - Schattenfeige (Feige, Unlicht)
  - Glanzkirsche (Kirsche, Licht)
- Fruchttypen haben Stärken und Schwächen, z.B. macht Feuer Wasser halben Schaden, Pflanzen doppelten,
 kriegt von Wasser doppelten und von Pflanzen halben Schaden
- Verschieden Attacken pro Frucht:
  - jede Frucht hat Attacke "Schlafen", kostet 0 und macht nix, nutzvoll zum sparen
  - eine mittelteure Attacke
  - eine teure Attacke
- einfaches Turn Based Gameplay gegen einen Bot
  - Man startet mit 2 "Dünger" was die Währung ist
  - Der Spieler darf eine Attacke für die er genügend Dünger hat spielen
  - Der Bot macht das gleiche
  - Dann kriegen der Spieler und der Bot mehr Dünger in ihre Düngerreserve
- Dünger Cycle:
  - +1 Dünger
  - +2 Dünger
  - +3 Dünger
  - +4 Dünger
  - +5 Dünger (noch ein Cycle)
  - +2 Dünger
  - +3 Dünger
  - +4 Dünger
  - +5 Dünger (noch ein Cycle)
  - +3 Dünger
  - +4 Dünger
  - +5 Dünger (noch ein Cycle)
  - +4 Dünger
  - +5 Dünger (ab hier nur noch +5 Dünger)
- Teambuilder in welchem man seine Team zusammenstellen kann
    - 4er Teams (4 verschiedene Früchte pro Team)
    - Jede Frucht maximal ein mal
    - Man kann seine Teams als .txt Datei speichern
    - Man kann .txt Dateien mit Teamdaten laden und somit sein Team reinladen


## Nice To Haves:
- Shop
- Lexikon in dem alle Früchte und deren Daten wie HP, Attacken stehen
- Chance für kritische Treffer (3x Schaden)
- Verschiedene Arenen
- Status Effekte wie Brennen, Vergiften, ...
- Intelligentere Bots
- Achievments
- Selbstheilungs "Attacken"
- Double Types (eine Frucht kann mehrere Types haben)

Das Game wird (sehr) grob so aussehen:
<img src="GUI.png" alt="GUI"/>


---

# Pflichtenheft: Architektur & Funktionsblöcke

## Class Diagram

KI: ChatGPT 
Prompt: Formatiere mein KlassenDiagramm schöner
und formatiere es für markdown
# Klassenübersicht – Fruit Battle Game

---

## `GameHandler`

| Sichtbarkeit | Typ         | Name                  |
| ------------ | ----------- | --------------------- |
| `+`          | `int`       | `RoundCount`          |
| `+`          | `int`       | `CurrentDungerPlayer` |
| `+`          | `int`       | `CurrentDungerEnemy`  |
| `+`          | `FruitTeam` | `PlayerTeam`          |
| `+`          | `FruitTeam` | `EnemyTeam`           |
| `+`          | `Fruit`     | `CurrentPlayerFruit`  |
| `+`          | `Fruit`     | `CurrentEnemyFruit`        |
| `+`          | `bool`      | `IsGameOver`          |

### Methoden

* `StartGame()`
* `NextRound()`
* `CalculateDamage() : int`
* `ApplyMove()`
* `HandleFaint()`
* `SwitchFruit()`
* `GetNextDungerValue() : int`


---

## `GameVisualizer`

| Sichtbarkeit | Typ      | Name            |
| ------------ | -------- | --------------- |
| `+`          | `Canvas` | `GameCanvas`    |
| `+`          | `Window` | `CurrentWindow` |

### Methoden

* `DrawBattleScene()`
* `UpdateHPBars()`
* `PlayAttackAnimation()`
* `ShowDamageText()`
* `UpdateDungerUI()`
* `SwitchMenuView()`
* `RefreshScreen()`

---

## `EnemyKI`

| Sichtbarkeit | Typ         | Name        |
| ------------ | ----------- | ----------- |
| `+`          | `FruitTeam` | `EnemyTeam` |

### Methoden

* `ChooseMove() : Move`
* `ChooseSwitchFruit() : int`
* `ShouldSwitch() : bool`

---

## `TeamBuilder`

| Sichtbarkeit | Typ         | Name          |
| ------------ | ----------- | ------------- |
| `+`          | `FruitTeam` | `CurrentTeam` |

### Methoden

* `AddFruit()`
* `RemoveFruit()`
* `ValidateTeam() : bool`
* `SaveTeam()`
* `LoadTeam()`

---

## `TeamBuilderUI`

| Sichtbarkeit | Typ           | Name              |
| ------------ | ------------- | ----------------- |
| `+`          | `List<Fruit>` | `AvailableFruits` |
| `+`          | `TeamBuilder` | `Builder`         |

### Methoden

* `DisplayFruits()`
* `AddFruitButton_Click()`
* `RemoveFruitButton_Click()`
* `SaveButton_Click()`
* `LoadButton_Click()`
* `StartGameButton_Click()`
* `UpdateTeamDisplay()`

---

## `Move`

| Sichtbarkeit | Typ         | Name          |
| ------------ | ----------- | ------------- |
| `+`          | `string`    | `Name`        |
| `+`          | `FruitType` | `Type`        |
| `+`          | `int`       | `Damage`      |
| `+`          | `int`       | `DungerCost`  |
| `+`          | `string`    | `Description` |

### Methoden

* `UseMove()`

---

## `Fruit`

| Sichtbarkeit | Typ           | Name           |
| ------------ | ------------- | -------------- |
| `+`          | `string`      | `Name`         |
| `+`          | `FruitType`   | `Type`         |
| `+`          | `int`         | `MaxHP`        |
| `+`          | `int`         | `CurrentHP`    |
| `+`          | `int`         | `Attack`       |
| `+`          | `int`         | `Defense`      |
| `+`          | `int`         | `Speed`        |
| `+`          | `bool`        | `IsAlive`      |
| `+`          | `Move[]`      | `MoveSet`      |
| `+`          | `UserControl` | `FruitControl` |

### Methoden

* `ReceiveDamage()`
* `Heal()`
* `AttackTarget()`
* `CheckAlive() : bool`
* `GetTypeMultiplier() : double`

---

## `FruitTeam`

| Sichtbarkeit | Typ       | Name               |
| ------------ | --------- | ------------------ |
| `+`          | `Fruit[]` | `Fruits`           |
| `+`          | `int`     | `ActiveFruitIndex` |

### Methoden

* `GetActiveFruit() : Fruit`
* `SwitchFruit()`
* `HasAliveFruit() : bool`
* `GetNextAliveFruit() : Fruit`

---

## `TypeEffectiveness`

| Sichtbarkeit | Typ                        | Name          |
| ------------ | -------------------------- | ------------- |
| `+`          | `Dictionary<Type, double>` | `Multipliers` |

### Methoden

* `GetMultiplier() : double`

---

## `DuengerCycle`

| Sichtbarkeit | Typ   | Name          |
| ------------ | ----- | ------------- |
| `+`          | `int` | `CurrentStep` |

### Methoden

* `GetNextValue() : int`
* `Reset()`

---

# `enum FruitType`

```csharp
enum FruitType
{
    Feuer,
    Wasser,
    Elektro,
    Pflanze,
    Eis,
    Erde,
    Flug,
    Psycho,
    Gift,
    Gestein,
    Unlicht,
    Licht
}
```

---

# Pflichtenheft: Detaillierte Umsetzungsbeschreibung

# Spielablauf

## Hauptmenü

Sobald man das Spiel startet sieht man drei Knöpfe:
- Start
- Exit
- Team Builder

### Start

Wenn man auf „Start" drückt, startet ein Kampf gegen einen Bot.  
Das Spiel kann nur gestartet werden, wenn das Team genau aus 4 Früchten besteht.

### Exit

Wenn man auf „Exit" drückt, schließt sich das Programm.

### Team Builder

Wenn man auf „Team Builder" drückt, kommt man auf eine neue Page.

Dort sieht man:
- alle verfügbaren Früchte
- links das aktuelle Team
- rechts die Speicher- und Ladeoptionen

#### Team bearbeiten

- Klickt man auf eine Frucht in der Liste, wird sie dem Team hinzugefügt.
- Klickt man links auf eine Frucht im Team, wird sie entfernt.
- Ein Team besteht aus genau 4 Früchten.

#### Speichern und Laden

Rechts gibt es:
- einen Speicher-Button
- einen Lade-Button

Diese können:
- das aktuelle Team als `.txt` Datei speichern
- ein Team aus einer `.txt` Datei laden

# Kampf-System

## Allgemein

Der Spieler kämpft gegen einen Bot.

Beide Seiten:
- starten mit 2 Dünger
- besitzen Teams aus mehreren Früchten

Es können Früchte während dem Kampf eingewechselt werden

Wenn die Lebenspunkte einer Frucht auf 0 fallen:
- wird diese aus dem Kampf gezogen
- eine neue Frucht __muss__ eingewechselt werden

Hat ein Spieler keine Früchte mehr:
- verliert dieser Spieler

Gewonnen hat:
- wer zuerst alle gegnerischen Früchte besiegt

# Früchte

Alle Früchte besitzen unterschiedliche Stats.

Die Stats sind:
- Lebenspunkte
- Angriff
- Verteidigung
- Geschwindigkeit

Jede Frucht kann außerdem unterschiedliche Attacken oder Attackentypen besitzen.

# Attacken

Es gibt mehrere Attackentypen.

Das folgende Bild zeigt das Typechart der verschiedenen Attackentypen:

![Typechart](Typechart.png)

Jede Frucht besitzt:
- eine kostenlose Attacke
- eine mittelteure Attacke
- eine teure Attacke

## Schlafen

Die Attacke „Schlafen":
- kostet 0 Dünger
- macht keinen Schaden
- überspringt den Zug

## Andere Attacken

Die anderen Attacken:
- kosten Dünger
- verursachen Schaden
- können je nach Attackentyp unterschiedliche Effekte besitzen

Ein Spieler kann nur Attacken auswählen, für die genug Dünger vorhanden ist.

# Zugablauf

1. Spieler wählt eine Attacke
2. Frucht mit höherer Geschwindigkeit attackiert zuerst
3. Die langsamere Frucht greift zurück an
4. Der Zug endet
5. Beide Seiten erhalten neuen Dünger

# Dünger-System

Nach jedem Zug erhalten beide Seiten Dünger.

Der Dünger-Cycle funktioniert wie folgt:

- +1 Dünger
- +2 Dünger
- +3 Dünger
- +4 Dünger
- +5 Dünger (Reset)
- +2 Dünger
- +3 Dünger
- +4 Dünger
- +5 Dünger (Reset)
- +3 Dünger
- +4 Dünger
- +5 Dünger (Reset)
- +4 Dünger
- +5 Dünger
- ab hier nur noch +5 Dünger

# Bot

Der Gegner ist ein Bot.

Der Bot:
- besitzt ebenfalls ein Team aus Früchten
- benutzt Attacken
- verwaltet Dünger wie der Spieler
- wechselt automatisch Früchte ein, wenn eine besiegt wurden

---

# Pflichtenheft: Probleme & Lösungen

# Fehler und Lösungen
## Welche Fehler hatten wir
- Ein großes Problem war das die Gegner ziemlich lang immer den falschen Move gewählt haben zuerst dachten wir das sie irgendwie zu stark sind aber es war der Fehler das sie egal wieviel Dünger sie haben immer denn starken Move wählten durch einen Fehler im Code. 
- Unsere wechsel Button gingen eine Zeit lang nicht bis wir herusgefunden haben das unsere UserControls zu groß waren und nicht durchklickbar waren und so über den Buttons gelegen sind.
- Hatten Probleme beim Speichern und beim Laden da die UserControls nicht mitspeicher bar waren dies haben wir dann mit einem JSonIgnore gefixt.

---

# Testbeschreibung

# Testbeschreibung
## Wie haben wir getestet
Wie haben unser Spiel folgendermaßen getetstet-
- Wir haben sehr viel herumprobiert geschaut kann das stimmen das wir soviel damage machen usw
- Manchmal KI drüber schauen lassen ob er Fehler im Code findet
