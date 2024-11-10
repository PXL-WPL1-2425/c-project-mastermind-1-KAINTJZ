using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic; 

namespace MasterMind1
{
    public partial class MainWindow : Window
    {
        private List<string> availibleColors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private List<string> secretCode;

        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomKleur();
            ComboBoxesKleurVuller();
        }

        // Random kleur generator + om in de titel weer te geven
        private void GenerateRandomKleur()
        {
            Random randomColorGenerator = new Random();
            secretCode = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                int index = randomColorGenerator.Next(availibleColors.Count);
                secretCode.Add(availibleColors[index]);
            }

            this.Title = "Secret kleur combinatie is: " + string.Join(", ", secretCode);
        }

        // ComboBoxen vullen met beschikbare kleuren
        private void ComboBoxesKleurVuller()
        {
            // Maak een lijst van ColorItem objecten met kleur en naam
            var colors = new List<ColorItem>
            {
                new ColorItem { Name = "Rood", Color = Colors.Red },
                new ColorItem { Name = "Geel", Color = Colors.Yellow },
                new ColorItem { Name = "Oranje", Color = Colors.Orange },
                new ColorItem { Name = "Wit", Color = Colors.White },
                new ColorItem { Name = "Groen", Color = Colors.Green },
                new ColorItem { Name = "Blauw", Color = Colors.Blue }
            };

            // Voeg de kleuren toe aan elke ComboBox
            RandomColorComboBox1.ItemsSource = colors;
            RandomColorComboBox2.ItemsSource = colors;
            RandomColorComboBox3.ItemsSource = colors;
            RandomColorComboBox4.ItemsSource = colors;
        }

        // Om kleur gegevens vast te stellen
        public class ColorItem
        {
            public string Name { get; set; }
            public Color Color { get; set; }
        }

  


        // Button functies: 

        // Kleuren checker
        private void Button_CheckColorCombination(object sender, RoutedEventArgs e)
        {
            
        }



        // Om applicatie te sluiten
        private void Button_LeaveGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

