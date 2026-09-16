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

namespace Gra_w_kosci_2026_desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Kosc[] dices = {
            new Kosc(0),
            new Kosc(0),
            new Kosc(0),
            new Kosc(0),
            new Kosc(0)
        };

        public Image[] diceElements;

        public MainWindow()
        {
            InitializeComponent();

            diceElements = new Image[] {
                kosc1, kosc2, kosc3, kosc4, kosc5
            };
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                Kosc dice = dices[i];
                Image diceElement = diceElements[i];

                dice.throwDice();
                diceElement.Source = new BitmapImage(new Uri(dice.filenames[dice.currentDiceFileIdx], UriKind.Relative));
                total += dice.currentDice;
            }
            txtResult.Text = total.ToString();
        }

        private void OnDiceClick(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            int tag = Convert.ToInt32(img.Tag);

            dices[tag].toggleLock();
            img.Opacity = dices[tag].diceAvailable ? 1.0 : 0.5;
        }
    }
}
