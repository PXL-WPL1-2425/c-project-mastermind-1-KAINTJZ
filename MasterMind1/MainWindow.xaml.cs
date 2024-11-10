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



namespace MasterMind1
{
    public partial class MainWindow : Window
    {
        private List<string> availibleColors = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
        private List<string> secretCode;

        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomCode();
        }

        // Random kleur generator
        private void GenerateRandomCode()
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

       


      
        // Kleuren checker
        private void Button_CheckColorCombination(object sender, RoutedEventArgs e)
        {

        }

        //Om applicatie te sluiten
        private void Button_LeaveGame(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}