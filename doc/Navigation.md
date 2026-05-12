# Spielablauf

## Hauptmenü

Sobald man das Spiel startet sieht man drei Knöpfe:
- Start
- Exit
- Team Builder

### Start

Wenn man auf „Start“ drückt, startet ein Kampf gegen einen Bot.  
Das Spiel kann nur gestartet werden, wenn das Team genau aus 4 Früchten besteht.

### Exit

Wenn man auf „Exit“ drückt, schließt sich das Programm.

### Team Builder

Wenn man auf „Team Builder“ drückt, kommt man auf eine neue Page.

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

Die Attacke „Schlafen“:
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
