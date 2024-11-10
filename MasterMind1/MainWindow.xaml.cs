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
        private List<string> secretCode = new List<string>();

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
            secretCode.Clear();

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
            public required string Name { get; set; }
            public Color Color { get; set; }
        }

        // Als je 1 van de ComboBoxen selectie veranderd dan:
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Haal de geselecteerde kleur op voor de juiste ComboBox
            ComboBox comboBox = sender as ComboBox;
            ColorItem selectedItem = comboBox.SelectedItem as ColorItem;

            if (selectedItem != null)
            {
                // Toon de naam van de geselecteerde kleur in de bijbehorende Label
                if (comboBox.Name == "RandomColorComboBox1")
                {
                    SelectedColorLabel1.Background = new SolidColorBrush(selectedItem.Color);
                }

                else if (comboBox.Name == "RandomColorComboBox2")
                {
                    SelectedColorLabel2.Background = new SolidColorBrush(selectedItem.Color);
                }

                else if (comboBox.Name == "RandomColorComboBox3")
                {
                    SelectedColorLabel3.Background = new SolidColorBrush(selectedItem.Color);
                }

                else if (comboBox.Name == "RandomColorComboBox4")
                {
                    SelectedColorLabel4.Background = new SolidColorBrush(selectedItem.Color);
                }
            }
        }

        // Button functies: 

        // Kleuren checker
        private void Button_CheckColorCombination(object sender, RoutedEventArgs e)
        {
            // Haal de geselecteerde kleuren van de ComboBoxen
            List<string> userCode = new List<string>
            {
            (RandomColorComboBox1.SelectedItem as ColorItem)?.Name,
            (RandomColorComboBox2.SelectedItem as ColorItem)?.Name,
            (RandomColorComboBox3.SelectedItem as ColorItem)?.Name,
            (RandomColorComboBox4.SelectedItem as ColorItem)?.Name
                };

            // Controleren of elke kleur overeenkomt met de geheime code
            for (int i = 0; i < 4; i++)
            {
                if (userCode[i] == secretCode[i])
                {
                    // Kleur is op de juiste plaats (donkerrood)
                    SetBorderColor(i, Colors.DarkRed);
                }
                else if (secretCode.Contains(userCode[i]))
                {
                    // Kleur komt voor, maar niet op de juiste plaats (wit)
                    SetBorderColor(i, Colors.Wheat);
                }
                else
                {
                    // Geen overeenkomst (geen rand)
                    SetBorderColor(i, Colors.Transparent);
                }
            }

        }

        

        // Functie om de randkleur van de labels te veranderen
        private void SetBorderColor(int index, Color borderColor)
        {
            switch (index)
            {
                case 0:
                    SelectedColorLabel1.BorderBrush = new SolidColorBrush(borderColor);
                    break;
                case 1:
                    SelectedColorLabel2.BorderBrush = new SolidColorBrush(borderColor);
                    break;
                case 2:
                    SelectedColorLabel3.BorderBrush = new SolidColorBrush(borderColor);
                    break;
                case 3:
                    SelectedColorLabel4.BorderBrush = new SolidColorBrush(borderColor);
                    break;
            }





        }

        // Button voor de Leave Game functie
        private void Button_LeaveGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
