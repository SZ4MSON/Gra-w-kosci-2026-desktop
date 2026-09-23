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
            new Kosc(0),
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            Image[] diceElements = { kosc1, kosc2, kosc3, kosc4, kosc5 };
            int total = 0;

            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].throwDice();

                total += dices[i].currentDice;

                diceElements[i].Source = new BitmapImage(
                    new Uri(
                        dices[i].filenames[dices[i].currentDiceFileIdx],
                        UriKind.Relative
                    )
                );
            }

            txtResult.Text = total.ToString();
        }

        private void OnDiceClick(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            int tag = Convert.ToInt32(img.Tag);

            if (dices[tag].diceAvailable == true)
            {
                dices[tag].toggleLock();
                img.Opacity = 0.5;
            }
            else
            {
                dices[tag].diceAvailable = true;
                img.Opacity = 1;
            }
        }
    }
}
