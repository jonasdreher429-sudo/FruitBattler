using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// KI ChatGPT
        // Prompt :
        // Ich habe dieses Typechart für mein Pokemon ähnliches Spiel erstelle
        // mir eine ganze c# Klasse welche TypeEffective heißt wenn. Ich kann
        // einer Funktion in dieser Klasse zwei Typen angeben wenn ich Type 1
        // ist der angreifende Typ und Type 2 ist der verteidigende sie soll
        // mir einen double zurückgeben -1 für nicht effective 0 für neutral
        // und 1 für sehr effektiv. ich habe ein enum genannt Type.cs nutze
        // dieses da sind alle Typen des typecharts drinnen.

        // KI Anfang

namespace FruitBattlerWPF.Classes
{
    using System.Collections.Generic;

    public static class TypeEffective
    {
        private static readonly Dictionary<(Type Attacker, Type Defender), double> Effectiveness = new()
    {
        // Feuer
        { (Type.Feuer, Type.Wasser), -1 },
        { (Type.Feuer, Type.Pflanze), 1 },
        { (Type.Feuer, Type.Eis), 1 },
        { (Type.Feuer, Type.Erde), -1 },
        { (Type.Feuer, Type.Gestein), -1 },
        { (Type.Feuer, Type.Licht), -1 },

        // Wasser
        { (Type.Wasser, Type.Feuer), 1 },
        { (Type.Wasser, Type.Wasser), -1 },
        { (Type.Wasser, Type.Elektro), -1 },
        { (Type.Wasser, Type.Erde), 1 },
        { (Type.Wasser, Type.Gift), -1 },
        { (Type.Wasser, Type.Gestein), -1 },
        { (Type.Wasser, Type.Licht), 1 },

        // Elektro
        { (Type.Elektro, Type.Wasser), 1 },
        { (Type.Elektro, Type.Elektro), -1 },
        { (Type.Elektro, Type.Erde), -1 },
        { (Type.Elektro, Type.Flug), 1 },
        { (Type.Elektro, Type.Gestein), -1 },

        // Pflanze
        { (Type.Pflanze, Type.Feuer), -1 },
        { (Type.Pflanze, Type.Wasser), 1 },
        { (Type.Pflanze, Type.Elektro), -1 },
        { (Type.Pflanze, Type.Eis), -1 },
        { (Type.Pflanze, Type.Erde), 1 },
        { (Type.Pflanze, Type.Flug), 1 },
        { (Type.Pflanze, Type.Gift), -1 },

        // Eis
        { (Type.Eis, Type.Feuer), -1 },
        { (Type.Eis, Type.Pflanze), 1 },
        { (Type.Eis, Type.Psycho), 1 },
        { (Type.Eis, Type.Gestein), -1 },

        // Erde
        { (Type.Erde, Type.Elektro), 1 },
        { (Type.Erde, Type.Pflanze), 1 },
        { (Type.Erde, Type.Erde), -1 },

        // Flug
        { (Type.Flug, Type.Elektro), -1 },
        { (Type.Flug, Type.Eis), 1 },
        { (Type.Flug, Type.Erde), -1 },

        // Psycho
        { (Type.Psycho, Type.Flug), -1 },
        { (Type.Psycho, Type.Unlicht), -1 },

        // Gift
        { (Type.Gift, Type.Pflanze), 1 },
        { (Type.Gift, Type.Erde), -1 },
        { (Type.Gift, Type.Psycho), -1 },
        { (Type.Gift, Type.Licht), 1 },

        // Gestein
        { (Type.Gestein, Type.Elektro), -1 },
        { (Type.Gestein, Type.Eis), 1 },
        { (Type.Gestein, Type.Flug), -1 },

        // Unlicht
        { (Type.Unlicht, Type.Psycho), 1 },
        { (Type.Unlicht, Type.Unlicht), -1 },
        { (Type.Unlicht, Type.Licht), -1 },

        // Licht
        { (Type.Licht, Type.Gift), -1 },
        { (Type.Licht, Type.Unlicht), 1 },
        { (Type.Licht, Type.Licht), -1 },
        };

        private static readonly HashSet<(Type Attacker, Type Defender)> Immunities = new()
        {
        (Type.Feuer, Type.Unlicht),
        (Type.Gift, Type.Gestein)
         };

        /// <summary>
        /// Rückgabe:
        /// -2 = Immun (kein Schaden)
        /// -1 = Nicht effektiv
        ///  0 = Neutral
        ///  1 = Sehr effektiv
        /// </summary>
        public static double GetEffectiveness(Type attackerType, Type defenderType)
        {
            if (Immunities.Contains((attackerType, defenderType)))
                return -2;

            return Effectiveness.TryGetValue((attackerType, defenderType), out double value)
                ? value
                : 0;
        }
    }
}
