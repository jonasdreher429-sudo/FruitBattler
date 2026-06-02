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