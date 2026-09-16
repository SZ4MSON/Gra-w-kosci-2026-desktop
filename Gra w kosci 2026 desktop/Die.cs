using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_kosci_2026_desktop
{
    public class Kosc
    {
        public static int instancesCounter = 0;
        private static Random _rnd = new Random();

        public string[] filenames = { "img/kosc0.png", "img/kosc1.png", "img/kosc2.png", "img/kosc3.png", "img/kosc4.png", "img/kosc5.png", "img/kosc6.png" };
        public int currentDice;
        public int currentDiceFileIdx;
        public bool diceAvailable;

        public Kosc(int currentDice)
        {
            int[] validValues = { 1, 2, 3, 4, 5, 6 };
            if (!validValues.Contains(currentDice))
            {
                currentDice = 0;
            }

            this.currentDice = currentDice;
            this.currentDiceFileIdx = currentDice;
            this.diceAvailable = true;
            Kosc.instancesCounter++;
        }

        public Kosc()
        {
            int roll = _rnd.Next(1, 7);

            this.currentDice = roll;
            this.currentDiceFileIdx = roll;
            this.diceAvailable = true;
            Kosc.instancesCounter++;
        }
    }
}