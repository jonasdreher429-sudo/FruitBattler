
// KI: Gemini 

// Prompt:

// (Fruit Klasse copy)

// die ist mein klasse fruit ich muss für diese 12 vershienden Früchte jeweils eine new Fruit erstellen bitte mache das für mich erstelle auch für jede frucht ein moveset der 1. move muss immer sleep sein dieser kostet 0 dünger und macht 0 damage

// /move Klasse copy)

// dies ist die move klasse jede frucht soll gebalanced sein da die stats funktionieren wie bei pokemon also keine frucht soll nicht deutlich stärker sein wie die andere. Jede Frucht soll einen stärkeren mover noch haben welcher den gleichen Typen hat wie die Frucht und einen schwächeren der einen anderen typ hat wie die Frucht. Der teure move soll 4-5 Dünger kosten und der schwache 2-3. Die Früchte lauten

//    12 Früchte mit jeweiligem Typen, HP, DMG

// 

//  - Pyronana(Banane, Feuer)

// 

//  - Aquabeere(Blaubeere, Wasser)

// 

//  - Voltimette(Limette, Elektro)

// 

//  - Florapfel(Apfel, Pflanze)

// 

//  - Frostube(Trabue, Eis)

// 

//  - Terrango(Mango, Erde)

// 

//  - Windpfirsich(Pfirsich, Flug)

// 

//  - Mystikokos(Kokosnuss, Psycho)

// 

//  - Toxibirne(Birne, Gift)

// 

//  - Knacknuss(Walnuss, Gestein)

// 

//  - Schattenfeige(Feige, Unlicht)

// 

//  - Glanzkirsche(Kirsche, Licht)

// also immer Move MOVENAME = new Move(...)

// also einmal für sleep dann für die anderen zwei Move dan zum beispiel für Glanzkirsche

// Fruit Glanzkirsche = new Fruit(...) mache das bitte für jede frucht



using System.Collections.Generic;
using FruitBattlerWPF;          // <-- WICHTIG: Holt dein eigenes 'Type'-Enum heran!
using FruitBattlerWPF.Classes;
using FruitBattlerWPF.UserControls; // WICHTIG: Damit die UserControls hier gefunden werden!

namespace FruitBattlerWPF.Classes
{
    public static class FruitGenerator
    {
        public static List<Fruit> CreateAllFruits()
        {
            List<Fruit> alleFruechte = new List<Fruit>();

            // ==========================================
            // DER STANDARD-MOVE FÜR ALLE FRÜCHTE
            // ==========================================
            Move sleepMove = new Move { Name = "Sleep", type = Type.Normal, Damage = 0, Duengercost = 0, Description = "Die Frucht ruht sich aus." };

            // ==========================================
            // 1. PYRONANA (Feuer) - Offensiv & Schnell
            // ==========================================
            Move pyroPfeffer = new Move { Name = "Feuerpfeffer", type = Type.Feuer, Damage = 45, Duengercost = 4, Description = "Ein feuriger, starker Angriff." };
            Move pyroFunke = new Move { Name = "Funkenflug", type = Type.Licht, Damage = 25, Duengercost = 2, Description = "Ein schwacher Lichtblitz." };

            Fruit pyronana = new Fruit("Pyronana", Type.Feuer, 60, 80, 50, 70, new Move[] { sleepMove, pyroPfeffer, pyroFunke }, new PyronanaUserControl());
            alleFruechte.Add(pyronana);

            // ==========================================
            // 2. AQUABEERE (Wasser) - Allrounder
            // ==========================================
            Move aquaWelle = new Move { Name = "Blattschuss", type = Type.Wasser, Damage = 40, Duengercost = 5, Description = "Eine heftige Wasserwelle." };
            Move aquaSchnitt = new Move { Name = "Frosthauch", type = Type.Eis, Damage = 20, Duengercost = 2, Description = "Ein kühler Windhauch." };

            Fruit aquabeere = new Fruit("Aquabeere", Type.Wasser, 70, 60, 65, 65, new Move[] { sleepMove, aquaWelle, aquaSchnitt }, new AquabeereUserControl());
            alleFruechte.Add(aquabeere);

            // ==========================================
            // 3. VOLTIMETTE (Elektro) - Extrem Schnell
            // ==========================================
            Move voltiSchock = new Move { Name = "Säureschock", type = Type.Elektro, Damage = 40, Duengercost = 4, Description = "Ein elektrisierender Saftangriff." };
            Move voltiSchnitt = new Move { Name = "Rückenwind", type = Type.Flug, Damage = 20, Duengercost = 2, Description = "Ein schneller Windstoß." };

            Fruit voltimette = new Fruit("Voltimette", Type.Elektro, 50, 65, 55, 90, new Move[] { sleepMove, voltiSchock, voltiSchnitt }, new VoltimetteUserControl());
            alleFruechte.Add(voltimette);

            // ==========================================
            // 4. FLORAPFEL (Pflanze) - Defensiver Heiler
            // ==========================================
            Move floraWurzel = new Move { Name = "Wurzelwürger", type = Type.Pflanze, Damage = 40, Duengercost = 4, Description = "Packt den Gegner mit Ranken." };
            Move floraMatsch = new Move { Name = "Matschbombe", type = Type.Erde, Damage = 25, Duengercost = 3, Description = "Wirft mit feuchter Erde." };

            Fruit florapfel = new Fruit("Florapfel", Type.Pflanze, 80, 50, 80, 50, new Move[] { sleepMove, floraWurzel, floraMatsch }, new FlorapfelUserControl());
            alleFruechte.Add(florapfel);

            // ==========================================
            // 5. FROSTUBE (Eis) - Taktischer Angreifer
            // ==========================================
            Move frostEiszapfen = new Move { Name = "Eiszapfenhagel", type = Type.Eis, Damage = 45, Duengercost = 5, Description = "Lässt scharfe Eiszapfen regnen." };
            Move frostBlase = new Move { Name = "Blasenschuss", type = Type.Wasser, Damage = 20, Duengercost = 2, Description = "Ein kleiner Wasserspritzer." };

            Fruit frostube = new Fruit("Frostube", Type.Eis, 65, 70, 60, 65, new Move[] { sleepMove, frostEiszapfen, frostBlase }, new FrostubeUserControl());
            alleFruechte.Add(frostube);

            // ==========================================
            // 6. TERRANGO (Erde) - Massiver Tank
            // ==========================================
            Move terraBeben = new Move { Name = "Erdbeben", type = Type.Erde, Damage = 45, Duengercost = 4, Description = "Lässt den Boden erzittern." };
            Move terraGift = new Move { Name = "Giftspritzer", type = Type.Gift, Damage = 25, Duengercost = 3, Description = "Sprüht ätzenden Saft." };

            Fruit terrango = new Fruit("Terrango", Type.Erde, 85, 65, 75, 35, new Move[] { sleepMove, terraBeben, terraGift }, new TerrangoUserControl());
            alleFruechte.Add(terrango);

            // ==========================================
            // 7. WINDPFIRSICH (Flug) - Sehr Flink
            // ==========================================
            Move windOrkan = new Move { Name = "Frucht-Orkan", type = Type.Flug, Damage = 40, Duengercost = 4, Description = "Ein mächtiger Wirbelsturm." };
            Move windSpore = new Move { Name = "Sporenschuss", type = Type.Pflanze, Damage = 20, Duengercost = 2, Description = "Wirft mit klebrigen Pollen." };

            Fruit windpfirsich = new Fruit("Windpfirsich", Type.Flug, 55, 70, 50, 85, new Move[] { sleepMove, windOrkan, windSpore }, new WindpfirsichUserControl());
            alleFruechte.Add(windpfirsich);

            // ==========================================
            // 8. MYSTIKOKOS (Psycho) - Hoher Schaden
            // ==========================================
            Move mystikTrance = new Move { Name = "Kokos-Trance", type = Type.Psycho, Damage = 50, Duengercost = 5, Description = "Ein mentaler Schock für den Gegner." };
            Move mystikFunke = new Move { Name = "Funke", type = Type.Elektro, Damage = 20, Duengercost = 2, Description = "Ein kleiner statischer Entladungsstoß." };

            Fruit mystikokos = new Fruit("Mystikokos", Type.Psycho, 65, 75, 55, 65, new Move[] { sleepMove, mystikTrance, mystikFunke }, new MystikokosUserControl());
            alleFruechte.Add(mystikokos);

            // ==========================================
            // 9. TOXIBIRNE (Gift) - Hinterhältig
            // ==========================================
            Move toxiToxin = new Move { Name = "Säurebad", type = Type.Gift, Damage = 40, Duengercost = 4, Description = "Übergießt den Gegner mit Gift." };
            Move toxiBiss = new Move { Name = "Finstere Aura", type = Type.Unlicht, Damage = 25, Duengercost = 3, Description = "Ein düsterer, schwacher Angriff." };

            Fruit toxibirne = new Fruit("Toxibirne", Type.Gift, 70, 65, 65, 60, new Move[] { sleepMove, toxiToxin, toxiBiss }, new ToxibirneUserControl());
            alleFruechte.Add(toxibirne);

            // ==========================================
            // 10. KNACKNUSS (Gestein) - Die unbesiegbare Mauer
            // ==========================================
            Move knackFels = new Move { Name = "Nussknacker-Fels", type = Type.Gestein, Damage = 40, Duengercost = 5, Description = "Lässt harte Steine herabregnen." };
            Move knackRamm = new Move { Name = "Bodenschlag", type = Type.Erde, Damage = 20, Duengercost = 2, Description = "Ein einfacher Schlag auf den Boden." };

            Fruit knacknuss = new Fruit("Knacknuss", Type.Gestein, 60, 55, 110, 35, new Move[] { sleepMove, knackFels, knackRamm }, new KnacknussUserControl());
            alleFruechte.Add(knacknuss);

            // ==========================================
            // 11. SCHATTENFEIGE (Unlicht) - Gefährlich
            // ==========================================
            Move schattenTerror = new Move { Name = "Alptraum-Fluch", type = Type.Unlicht, Damage = 45, Duengercost = 4, Description = "Greift aus den Schatten heraus an." };
            Move schattenPsy = new Move { Name = "Gedankenschlag", type = Type.Psycho, Damage = 25, Duengercost = 3, Description = "Ein kleiner Psycho-Trick." };

            Fruit schattenfeige = new Fruit("Schattenfeige", Type.Unlicht, 55, 80, 55, 70, new Move[] { sleepMove, schattenTerror, schattenPsy }, new SchattenfeigeUserControl());
            alleFruechte.Add(schattenfeige);

            // ==========================================
            // 12. GLANZKIRSCHE (Licht) - Edel & Ausgewogen
            // ==========================================
            Move glanzStrahl = new Move { Name = "Solar-Laser", type = Type.Licht, Damage = 45, Duengercost = 4, Description = "Ein gebündelter Strahl aus purem Licht." };
            Move glanzGlut = new Move { Name = "Kleine Glut", type = Type.Feuer, Damage = 25, Duengercost = 3, Description = "Ein winziges Flämmchen." };

            Fruit glanzkirsche = new Fruit("Glanzkirsche", Type.Licht, 60, 70, 55, 75, new Move[] { sleepMove, glanzStrahl, glanzGlut }, new GlanzkirscheUserControl());
            alleFruechte.Add(glanzkirsche);

            return alleFruechte;
        }
    }
}