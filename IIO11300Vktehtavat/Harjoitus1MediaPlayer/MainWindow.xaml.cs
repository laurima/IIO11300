using Microsoft.Win32;
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

namespace Harjoitus1MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadMediaFile()
        {
            try {
                //ladataan käyttäjän valitsemaa mediatiedostoa
                //string filu = @"\\storage.labranet.jamk.fi\homes\salesa\Jakoon\iio11300\Media\CoffeeMaker.mp4";
                string filu = txtFileName.Text;
                //tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    //MessageBox.Show("Playing: " + filu);
                    mediaElement.Source = new Uri(filu);

                }
                else { 
                    MessageBox.Show("No " + "such " +  "file");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            LoadMediaFile();
            mediaElement.Play();
            ChangeButtonState();
        }

        private void btmUrl_Click(object sender, RoutedEventArgs e)
        {
            //avataan vakio Open-dialogi jotta käyttäjä voi valita yhden tiedoston
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\";
            dlg.Filter = "Rock Files (*.mp3)|*.mp3|Media files (*.wmv)|*.wmv|All files (*.)|*.";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            ChangeButtonState();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            ChangeButtonState();
        }

        private void txtFileName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ChangeButtonState()
        {
            //muutetaan nappuloiden tilaa
            btnPause.IsEnabled = !btnPause.IsEnabled;
            btnStop.IsEnabled = !btnStop.IsEnabled;
            btnPlay.IsEnabled = !btnPlay.IsEnabled;
        }
    }
}
