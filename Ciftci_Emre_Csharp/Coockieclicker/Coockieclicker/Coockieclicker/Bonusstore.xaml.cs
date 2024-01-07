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
using System.Windows.Shapes;

namespace Coockieclicker
{
    /// <summary>
    /// Interaction logic for Bonusstore.xaml
    /// </summary>
    public partial class Bonusstore : Window
    {
        double gekochteBonussen = 0;
        double prijsNobura = 15;
        double prijsTodo = 10000;
        double prijsGojo = 110000;
        double prijsSukuna = 120000;
        double prijsNanami = 13000000;
        double prijsToji = 14000000000;
        double prijsYuta = 20000000000;
        

        
        public Bonusstore()
        {
           
            InitializeComponent();
            lblprijsnobura.Content = prijsNobura;
        }

        private double bonus(double basisPrijs)
        {
            if (gekochteBonussen == 1)
            {
                basisPrijs = basisPrijs * 100;



            }
            else if (gekochteBonussen == 2)
            {
                basisPrijs = basisPrijs * 500;
            }
            else if (gekochteBonussen == 3)
            {
                basisPrijs = basisPrijs * 5000;
            }
            else if (gekochteBonussen == 4)
            {
                basisPrijs = basisPrijs * 50000;
            }
            else if (gekochteBonussen == 5)
            {
                basisPrijs = basisPrijs * 500000;
            }
            else
            {
                
                basisPrijs = basisPrijs * 500000;
            }
            
            return basisPrijs;
           
        }


        private double prijsvermindering(double prijs)
        {
            double bonusPrijs = bonus(prijs);
            if (MainWindow.score >= bonusPrijs)
            {
                MainWindow.score -= bonusPrijs;
                
            }
            return bonusPrijs;
            
        }
        

        private void btnNobura_Click(object sender, RoutedEventArgs e)
        {
            gekochteBonussen++;
            lblprijsnobura.Content =prijsvermindering(prijsNobura);
            
            
        }

        private void btntodo_Click(object sender, RoutedEventArgs e)
        {
            //basisPrijs = 100;
            gekochteBonussen++;
            //bonus();
           //prijsvermindering();
            //lblprijstodo.Content = string.Format("{0:#,0}", basisPrijs);
         

        }

        private void btngojo_Click(object sender, RoutedEventArgs e)
        {
          //  basisPrijs = 1100;
           // bonus();
        }

        private void btnsukuna_Click(object sender, RoutedEventArgs e)
        {
          //  basisPrijs = 12000;
           // bonus();
        }

        private void btnnanami_Click(object sender, RoutedEventArgs e)
        {
          // basisPrijs = 130000;
           // bonus();
        }

        private void btntoji_Click(object sender, RoutedEventArgs e)
        {
           // basisPrijs = 1400000;
           // bonus();
        }

        private void btnyuta_Click(object sender, RoutedEventArgs e)
        {
           // basisPrijs = 20000000;
           // bonus();
        }
    }
}
