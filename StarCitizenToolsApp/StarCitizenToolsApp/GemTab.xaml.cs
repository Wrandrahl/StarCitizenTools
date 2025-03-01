using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarCitizenToolsApp
{
    /// <summary>
    /// Logique d'interaction pour SecondTab.xaml
    /// </summary>
    public partial class GemTab : UserControl
    {
        public GemTab()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            var rocks = new List<RockData>
            {
                new RockData("Felsic", 1770),
                new RockData("Gneiss", 1840),
                new RockData("Granite", 1920),
                new RockData("Igneous", 1950),
                new RockData("Obsidian", 1790),
                new RockData("Quartzite", 1820),
                new RockData("Atacamite", 1800),
                new RockData("Shale", 1730)
            };

            RocksDataGrid.ItemsSource = rocks;
        }
    }
}
