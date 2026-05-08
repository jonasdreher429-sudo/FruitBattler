# Fruit Battler
## von Jonas und Marko

Wir planen ein Spiel in WPF zu programmieren, in welchem man mit seinem Team von Früchten in jeweiligen 1v1s gegen die Früchte des Gegner Bots kämpft. Das Spiel soll ein Turn Based Game sein, mit Früchten welche verschiedene Fruchttypen haben, Attacken mit verschiedenen Kosten, und einem Team Builder in welchem man sein Team aus Früchten fabrizieren kann.


## Must Haves:
- 12 Früchte mit jeweiligem Typen, HP, DMG
  - Pyronana (Banane, Feuer)
  - Aquabeere (Blaubeere, Wasser)
  - Voltimette (Limette, Elektro)
  - Florapfel (Apfel)
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



## Realisierung der Must Haves:
-Klassen-



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
| `+`          | `Fruit`     | `CurrentEnemyFruit`   |
| `+`          | `bool`      | `IsGameOver`          |

### Methoden

* `StartGame()`
* `NextRound()`
* `CalculateDamage() : int`
* `ApplyMove()`
* `HandleFaint()`
* `SwitchFruit()`
* `GetNextDungerValue() : int`
* `CheckWinCondition() : bool`
* `EndGame()`

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

## `DungerCycle`

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
