/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 20.1.2016
* Authors: Lauri Mäkinen, Esa Salmikangas
*/
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

namespace Tehtava1
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {

                double ikkunanKorkeus, ikkunanLeveys, karminPaksuus, karminPiiri, karminAla, ikkunanAla;

                ikkunanKorkeus = Double.Parse(txtikkunanKorkeus.Text);
                ikkunanLeveys = Double.Parse(txtikkunanLeveys.Text);
                karminPaksuus = Double.Parse(txtkarminPaksuus.Text);

                // Laske ikkunan alue
                ikkunanAlue = ikkunanKorkeus * ikkunanLeveys;

                // Laske karmin piiri
                karminPiiri = BusinessLogicWindow.laskePiiri(ikkunanKorkeus + karminPaksuus, ikkunanLeveys + karminPaksuus);

                // Laske karmin alue
                karminAlue = (ikkunanLeveys + karminPaksuus * 2) * (ikkunanKorkeus + karminPaksuus * 2) - ikkunanAlue;

                // Output
                txtkarminAlue.Text = Convert.ToString(karminAlue);
                txtkarminPiiri.Text = Convert.ToString(karminPiiri);
                txtikkunanAlue.Text = Convert.ToString(ikkunanAlue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      //käynnissä olevan sovelluksen sulkeminen
      Application.Current.Shutdown();
    }
  }

  public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static double laskePiiri(double leveys, double korkeus)
        {
            return leveys * 2 + korkeus * 2;
        }
    }


}
