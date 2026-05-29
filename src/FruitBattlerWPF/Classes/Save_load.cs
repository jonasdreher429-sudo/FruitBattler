using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace FruitBattlerWPF.Classes
{
    public static class Save_load
    {
        public static void save(List<Fruit> fruits)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Textdateien(*.txt) | *.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Bitte wähle einen Speicherort";

            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                
                try
                {
                    string inhalt = JsonSerializer.Serialize(fruits);
                    File.WriteAllText(filePath,inhalt);
                    MessageBox.Show("Team erflogreich gespeichert");
                }
                catch 
                {
                    MessageBox.Show("Fehler beim speichern des Teams");
                }
            }
        }

        public static List<Fruit> Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Textdateien (*.txt)|*.txt";
            openFileDialog.Title = "Bitte wähle eine Datei zum Öffnen aus";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string dateiInhalt = File.ReadAllText(filePath);
                    
                    List<Fruit> fruits = JsonSerializer.Deserialize<List<Fruit>>(dateiInhalt);
                    if (fruits.Count != 4)
                    {
                        throw new Exception("Team zu lang oder zu kurz");
                    }
                    return fruits;
                    
                }
                catch
                {
                    MessageBox.Show($"Fehler beim Laden des Teams");
                    return null;
                }
            }
            return null;
        }
    }
}
