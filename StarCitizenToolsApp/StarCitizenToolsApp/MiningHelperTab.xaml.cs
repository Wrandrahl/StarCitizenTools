using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StarCitizenToolsApp
{
    public partial class MiningHelperTab : UserControl
    {
        public MiningHelperTab()
        {
            InitializeComponent();
        }

        private const string Copper = "Copper (Ore)";
        private const string Agricium = "Agricium (Ore)";
        private const string Beryl = "Beryl (Raw)";
        private const string Bexalite = "Bexalite (Raw)";
        private const string Borase = "Borase (Ore)";
        private const string Aluminum = "Aluminum(Ore)";
        private const string Corundum = "Corundum (Raw)";
        private const string Gold = "Gold (Ore)";
        private const string Hephaestanite = "Hephaestanite (Raw)";
        private const string Iron = "Iron (Ore)";
        private const string Laranite = "Laranite (Raw)";
        private const string Quantainium = "Quantainium (Raw)";
        private const string Quartz = "Quartz (Raw)";
        private const string Taranite = "Taranite (Raw)";
        private const string Titanium = "Titanium (Ore)";
        private const string Tungsten = "Tungsten (Ore)";


        private readonly (string Name, int Value, string ImagePath, string[] Resources)[] Rocks =
        {
            ("Atacamite", 1800, "pack://application:,,,/data/deposit/Atacamite.png", new string[] { Copper, Agricium, Bexalite, Aluminum ,Corundum,Gold,Hephaestanite ,Iron ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Felsic", 1770, "pack://application:,,,/data/deposit/Felsic.png", new string[] { Copper, Beryl, Bexalite, Aluminum ,Corundum,Gold ,Iron ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Gneiss", 1840, "pack://application:,,,/data/deposit/Gneiss.png", new string[] { Copper, Bexalite, Aluminum ,Corundum,Gold,Hephaestanite ,Iron ,Quantainium ,Quartz,Taranite,Titanium}),
            ("Granite", 1920, "pack://application:,,,/data/deposit/Granite.png", new string[] { Copper, Bexalite, Borase, Aluminum,Corundum,Gold  ,Iron ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Quartzite", 1820, "pack://application:,,,/data/deposit/Quartzite.png", new string[] { Copper, Agricium, Bexalite, Aluminum,Corundum,Gold,Hephaestanite  ,Iron ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Igneous", 1950, "pack://application:,,,/data/deposit/Igneous.png", new string[] { Copper, Bexalite, Aluminum ,Corundum,Gold ,Iron,Laranite ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Obsidian", 1790, "pack://application:,,,/data/deposit/Obsidian.png", new string[] { Copper, Beryl, Bexalite, Borase, Aluminum,Corundum,Gold ,Iron ,Quantainium ,Quartz,Taranite,Titanium,Tungsten}),
            ("Shale", 1730, "pack://application:,,,/data/deposit/Shale.png", new string[] { Copper, Bexalite, Aluminum,Corundum,Gold ,Iron, Laranite ,Quantainium ,Quartz,Taranite,Titanium,Tungsten})
        };

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessInput();
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (!int.TryParse(InputTextBox.Text, out int value))
            {
                ResultTextBlock.Text = "Entrée invalide";
                ResultImage.Visibility = Visibility.Collapsed;
                ResourcesListBox.Visibility = Visibility.Collapsed;
                return;
            }

            foreach (var rock in Rocks)
            {
                if (value % rock.Value == 0)
                {
                    int quantity = value / rock.Value;
                    ResultTextBlock.Text = $"{rock.Name} ({quantity})";

                    // Chargement de l'image
                    try
                    {
                        ResultImage.Source = new BitmapImage(new Uri(rock.ImagePath, UriKind.Absolute));
                        ResultImage.Visibility = Visibility.Visible;
                    }
                    catch
                    {
                        ResultImage.Visibility = Visibility.Collapsed;
                    }

                    // Affichage des ressources associées sous forme horizontale
                    ResourcesListBox.ItemsSource = rock.Resources;
                    ResourcesListBox.Visibility = Visibility.Visible;

                    return;
                }
            }

            ResultTextBlock.Text = "Aucune roche correspondante";
            ResultImage.Visibility = Visibility.Collapsed;
            ResourcesListBox.Visibility = Visibility.Collapsed;
        }
    }
}
