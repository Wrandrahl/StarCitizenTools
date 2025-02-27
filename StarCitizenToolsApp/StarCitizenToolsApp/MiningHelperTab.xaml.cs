using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace StarCitizenToolsApp
{
    /// <summary>
    /// Logique d'interaction pour MiningHelperTab.xaml
    /// </summary>
    public partial class MiningHelperTab : UserControl
    {
        public MiningHelperTab()
        {
            InitializeComponent();
        }

        private readonly (string Name, int Value, string ImagePath)[] Rocks =
{
            ("Felsic", 1770, "data/deposit/Felsic.png"),
            ("Gneiss", 1840, "data/deposit/Gneiss.png"),
            ("Granite", 1920, "data/deposit/Granite.png"),
            ("Igneous", 1950, "data/deposit/Igneous.png"),
            ("Obsidian", 1790, "data/deposit/Obsidian.png"),
            ("Quartzite", 1820, "data/deposit/Quartzite.png"),
            ("Atacamite", 1800, "data/deposit/Atacamite.png"),
            ("Shale", 1730, "data/deposit/Shale.png")
        };

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate_Click(sender, e);
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int value))
            {
                Calculate_Click(sender, e); // On réutilise la méthode existante pour éviter de dupliquer du code
            }
            else
            {
                ResultTextBlock.Text = "Entrée invalide";
                ResultImage.Source = null;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int value))
            {
                foreach (var rock in Rocks)
                {
                    if (value % rock.Value == 0)
                    {
                        int quantity = value / rock.Value;
                        ResultTextBlock.Text = $"{rock.Name} ({quantity})";

                        // Construire le chemin vers la ressource intégrée
                        string imagePath = $"pack://application:,,,/data/deposit/{rock.Name}.png";

                        try
                        {
                            ResultImage.Source = new BitmapImage(new Uri(imagePath));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur chargement image : {ex.Message}");
                            ResultImage.Source = null;
                        }
                        return;
                    }
                }
                ResultTextBlock.Text = "Aucune roche correspondante";
                ResultImage.Source = null;
            }
            else
            {
                ResultTextBlock.Text = "Entrée invalide";
                ResultImage.Source = null;
            }
        }
    }
}
