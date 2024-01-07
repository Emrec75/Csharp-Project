using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Coockieclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static double score = 0;
        double totaalscore = 0;
        double passieveinkomen = 0;
        double prijsnobura = 15;
        double prijstodo = 100;
        double prijsgojo = 1100;
        double prijssukuna = 12000;
        double prijsnanami = 130000;
        double prijstoji = 1400000;
        double prijsyuta = 20000000;
        int lvlnobura = 0, lvltodo = 0, lvlsukuna = 0, lvlgojo = 0, lvlnanami = 0, lvltoji = 0, lvlyuta = 0;
        private DispatcherTimer goldenCookieTimer;
        private Image goldenCookie;
        private Random random = new Random();


        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            showInvestment();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            imgNobura.Visibility = Visibility.Hidden;
            imgTodo.Visibility = Visibility.Hidden;
            imgGojo.Visibility = Visibility.Hidden;
            imgSukuna.Visibility = Visibility.Hidden;
            imgNanami.Visibility = Visibility.Hidden;
            imgToji.Visibility = Visibility.Hidden;
            imgYuta.Visibility = Visibility.Hidden;
            lblAllies.Visibility = Visibility.Hidden;
            btnBonus.Visibility = Visibility.Hidden;
        
            goldenCookieTimer = new DispatcherTimer();
            goldenCookieTimer.Interval = TimeSpan.FromMinutes(1);
            goldenCookieTimer.Tick += GoldenCookieTimer_Tick;
            goldenCookieTimer.Start();

            
            goldenCookie = new Image();
            goldenCookie.Source = new BitmapImage(new Uri("images/golden2.png", UriKind.Relative));
            goldenCookie.Width = 200; 
            goldenCookie.Height = 200;
            goldenCookie.Visibility = Visibility.Hidden;
            goldenCookie.MouseDown += GoldenCookie_Click;
            GoldenCookieCanvas.Children.Add(goldenCookie);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            totaalscore += passieveinkomen;
            score += passieveinkomen;
            scoreUpdate();
            showInvestment();
            if (passieveinkomen > 0)
            {
                CreateFallingCookie();
            }
        }       

        private void Btnnobura_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijsnobura)
            {
                lvlnobura++;
                lbllvlnobura.Content = lvlnobura;
                score -= prijsnobura;
                prijsnobura = prijsnobura * Math.Pow(1.15, lvlnobura);
                lblprijsnobura.Content = string.Format("{0:#,0}", prijsnobura);
                passieveinkomen += 0.1;
                lblAllies.Visibility = Visibility.Visible;
                imgNobura.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }

        private void btntodo_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijstodo)
            {
                lvltodo++;
                lbllvltodo.Content = lvltodo;
                score -= prijstodo;
                prijstodo = prijstodo * Math.Pow(1.15, lvltodo);
                lblprijstodo.Content = string.Format("{0:#,0}", prijstodo);
                passieveinkomen += 1;
                lblAllies.Visibility = Visibility.Visible;
                imgTodo.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }
        private void btngojo_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijsgojo)
            {
                lvlgojo++;
                lbllvlgojo.Content = lvlgojo;
                score -= prijsgojo;
                prijsgojo = prijsgojo * Math.Pow(1.15, lvlgojo);
                lblprijsgojo.Content = string.Format("{0:#,0}", prijsgojo);
                passieveinkomen += 8;
                lblAllies.Visibility = Visibility.Visible;
                imgGojo.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }

        private void btntoji_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijstoji)
            {
                lvltoji++;
                lbllvltoji.Content = lvltoji;
                score -= prijstoji;
                prijstoji = prijstoji * Math.Pow(1.15, lvltoji);
                lblprijstoji.Content = string.Format("{0:#,0}", prijstoji);
                passieveinkomen += 1400;
                lblAllies.Visibility = Visibility.Visible;
                imgToji.Visibility = Visibility.Visible;
               
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }

        private void btnyuta_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijsyuta)
            {
                lvlyuta++;
                lbllvlyuta.Content = lvlyuta;
                score -= prijsyuta;
                prijsyuta = prijsyuta * Math.Pow(1.15, lvlyuta);
                lblprijsyuta.Content = string.Format("{0:#,0}", prijsyuta);
                passieveinkomen += 7800;
                lblAllies.Visibility = Visibility.Visible;
                imgYuta.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }

        private void btnsukuna_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijssukuna)
            {
                lvlsukuna++;
                lbllvlsukuna.Content = lvlsukuna;
                score -= prijssukuna;
                prijssukuna = prijssukuna * Math.Pow(1.15, lvlsukuna);
                lblprijssukuna.Content = string.Format("{0:#,0}", prijssukuna);
                passieveinkomen += 47;
                lblAllies.Visibility = Visibility.Visible;
                imgSukuna.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }
        }

        private void btnBonus_Click(object sender, RoutedEventArgs e)
        {
            Bonusstore bonusStore = new Bonusstore();
            if (bonusStore.ShowDialog() == true)
            {
               

               
            }
        }

        private void imgitadori_MouseDown(object sender, MouseButtonEventArgs e)
        {
            totaalscore++;
            score++;
            imgitadori.Width = 175;
            scoreUpdate();
            showInvestment();
            CreateFallingCookie();

        }

        private void showInvestment()
        {
            btnnobura.Visibility = Visibility.Hidden;
            btntodo.Visibility = Visibility.Hidden;
            btngojo.Visibility = Visibility.Hidden;
            btnsukuna.Visibility = Visibility.Hidden;
            btnnanami.Visibility = Visibility.Hidden;
            btntoji.Visibility = Visibility.Hidden;
            btnyuta.Visibility = Visibility.Hidden;

            if (totaalscore >= 20000000)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
                btngojo.Visibility = Visibility.Visible;
                btnsukuna.Visibility = Visibility.Visible;
                btnnanami.Visibility = Visibility.Visible;
                btntoji.Visibility = Visibility.Visible;
                btnyuta.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 1400000)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
                btngojo.Visibility = Visibility.Visible;
                btnsukuna.Visibility = Visibility.Visible;
                btnnanami.Visibility = Visibility.Visible;
                btntoji.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 130000)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
                btngojo.Visibility = Visibility.Visible;
                btnsukuna.Visibility = Visibility.Visible;
                btnnanami.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 12000)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
                btngojo.Visibility = Visibility.Visible;
                btnsukuna.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 1100)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
                btngojo.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 100)
            {
                btnnobura.Visibility = Visibility.Visible;
                btntodo.Visibility = Visibility.Visible;
            }
            else if (totaalscore >= 15)
            {
                btnnobura.Visibility = Visibility.Visible;
                btnBonus.Visibility = Visibility.Visible;
            }            
        }

        private void scoreUpdate()
        {
            if (score >= 1e18)
            {
                lblscore.Content = $"{Math.Round(score / 1e18, 2)} Triljoen Curses";
            }
            else if (score >= 1e15)
            {
                lblscore.Content = $"{Math.Round(score / 1e15, 2)} Biljard Curses";
            }
            else if (score >= 1e12)
            {
                lblscore.Content = $"{Math.Round(score / 1e12, 2)} Biljoen Curses";
            }
            else if (score >= 1e9)
            {
                lblscore.Content = $"{Math.Round(score / 1e9, 2)} Miljard Curses";
            }
            else if (score >= 1e6)
            {
                lblscore.Content = $"{Math.Round(score / 1e6, 2)} Miljoen Curses";
            }

            else if (score >= 1000)
            {
                lblscore.Content = $"{score:# ###.00} Curses";
            }

            else
            {
                lblscore.Content = $"{Math.Round(score, 2)} Curses";
            }
        }
       
        private void imgitadori_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            imgitadori.Width = ActualWidth;
            
        }

        private void lblsorcerernaam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                string userInput = inputDialog.UserInput;
                
                lblsorcerernaam.Content = userInput;
            }

        }

        private void btnnanami_Click(object sender, RoutedEventArgs e)
        {
            if (score >= prijsnanami)
            {
                lvlnanami++;
                lbllvlnanami.Content = lvlnanami;
                score -= prijsnanami;
                prijsnanami = prijsnanami * Math.Pow(1.15, lvlnanami);
                lblprijsnanami.Content = prijsnanami;
                lblprijsnanami.Content = string.Format("{0:#,0}", prijsnanami);
                passieveinkomen += 260;
                lblAllies.Visibility = Visibility.Visible;
                imgNanami.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg curses gevangen!");
            }

        }
        private void GoldenCookieTimer_Tick(object sender, EventArgs e)
        {
            if (random.NextDouble() < 0.3) 
            {
              
                ShowGoldenCookie();
            }
        }

        private void ShowGoldenCookie()
        {
            int maxWidth = (int)GoldenCookieCanvas.ActualWidth - (int)goldenCookie.Width;
            int maxHeight = (int)GoldenCookieCanvas.ActualHeight - (int)goldenCookie.Height;
            int x = random.Next(0, maxWidth);
            int y = random.Next(0, maxHeight);

            Canvas.SetLeft(goldenCookie, x);
            Canvas.SetTop(goldenCookie, y);

            goldenCookie.Visibility = Visibility.Visible;

            Task.Delay(10000).ContinueWith(t => HideGoldenCookie());


        }

        private void HideGoldenCookie()
        {
            Dispatcher.Invoke(() =>
            {
                goldenCookie.Visibility = Visibility.Hidden;
            });
        }

        private void GoldenCookie_Click(object sender, MouseButtonEventArgs e)
        {
            score += passieveinkomen * 900; 

            HideGoldenCookie();

            
            scoreUpdate();
            showInvestment();
        }
        private void CreateFallingCookie()
        {
            if (FallingCookiesCanvas.Children.Count > 50)
                return;

            Image fallingCookie = new Image();
            fallingCookie.Source = new BitmapImage(new Uri("images/heavenlyspear.png", UriKind.Relative));
            fallingCookie.Width = 80;
            fallingCookie.Height = 80;

            int x = random.Next(0, (int)FallingCookiesCanvas.ActualWidth - (int)fallingCookie.Width);
            Canvas.SetLeft(fallingCookie, x);
            Canvas.SetTop(fallingCookie, -fallingCookie.Height);

            FallingCookiesCanvas.Children.Add(fallingCookie);

            DoubleAnimation fallAnimation = new DoubleAnimation
            {
                From = -fallingCookie.Height,
                To = FallingCookiesCanvas.ActualHeight,
                Duration = new Duration(TimeSpan.FromSeconds(5))
            };

            fallAnimation.Completed += (s, e) => FallingCookiesCanvas.Children.Remove(fallingCookie);
            fallingCookie.BeginAnimation(Canvas.TopProperty, fallAnimation);
        }
    }
}
