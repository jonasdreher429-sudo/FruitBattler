using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FruitBattlerWPF.Classes
{
    public class Fruit
    {
        public string Name = string.Empty;
        public Type FruitType;
        public int MaxHP;
        public int CurrentHP;
        public int Attack;
        public int Defense;
        public int Speed;
        public bool IsAlive;
        public Move[] MoveSet;
        public UserControl? FruitControl;

        public Fruit() { }

        public Fruit(string name,Type fruittype,int maxhp,int attack,int deffense, int speed, Move[] moveset, UserControl FruitControl)
        {
            Name = name;
            FruitType = fruittype;
            MaxHP = maxhp;
            CurrentHP = MaxHP;
            Attack = attack;
            Defense = deffense;
            Speed = speed;
            IsAlive = true;
            MoveSet = moveset;
        }


        public void ReceiveDamage(Fruit enemyFruit, Move move)
        {
            // KI: ChatGPT
            // Prompt: das ist meine klasse für mein pokemon ähnliches spiel bitte gebe mir eine formel
            // für meine funktion ReceiveDamage in der Fruit klasse die funktion gibt nichts zurück sondern
            // soll die CurrentHP der Frucht abziehen. Der Funktion wird die gegnerische Frucht mitgegeben
            // das stab damage berechnet werden kann


            // KI Anfang

            // Basis-Schaden
            double damage = ((double)enemyFruit.Attack / Defense) * move.Damage;

            // STAB Bonus
            if (enemyFruit.FruitType == move.type)
            {
                damage *= 1.5;
            }

            

            // Mindestens 1 Schaden
            int finalDamage = Math.Max(1, (int)Math.Round(damage));

            // HP abziehen
            CurrentHP -= finalDamage;

            // Nicht unter 0
            if (CurrentHP < 0)
            {
                CurrentHP = 0;
            }

            // Todesstatus
            if (CurrentHP == 0)
            {
                IsAlive = false;
            }


            // KI Ende
        }

        public bool CheckAlive()
        {
            return IsAlive;
        }



    }
}
