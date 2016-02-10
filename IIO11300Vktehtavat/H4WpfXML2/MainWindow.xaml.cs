﻿using System;
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
using System.Xml;
using System.Xml.Linq;

namespace H4WpfXML2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement xe;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ladataan xml-tiedosto ja asetetaan se Datagridin data contextiksi
                xe = XElement.Load(GetFileName());
                dgData.DataContext = xe.Elements("tyontekija");
                //lasketaan työntekijöiden määrä ja palkkasumma ja näytetään ne käyttäjälle
                int lkm = 0;
                lkm = xe.Elements().Count();
                tbMessage.Text = string.Format("Akun tehtaalla on {0} työntekijää, joista vakituisia on {1} ja palkat yhteensä {2}", lkm, CountWorkers("vakituinen"), CalculateSalarySum());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }


        private string GetFileName()
        {
            //älä kovakoodaa muuttuvia asioita koodiin
            //return "d:\\Tyontekijat2013.xml";
            //parempi tapa on sijoittaa ne App.Config tiedostoon
            return H4WpfXML2.Properties.Settings.Default.XNLTiedosto;
        }
        private decimal CalculateSalarySum()
        {
            decimal result = 0;
            //haetaan työntekijöiden palkan xml:stä (XElement olioon) LINQ kyselyllä
            var palkat = from ele in xe.Elements()
                         select ele.Element("palkka");
            foreach (var item in palkat)
            {
                result += decimal.Parse(item.Value);
            }
            return result;
        }
        private int CountWorkers(string tyosuhde)
        {
            //lasketaan annetut työsuhteen mukaiset työntekijät LINQ-kyselyllä
            var tyontekijat = from ele in xe.Elements()
                              where ele.Element("tyosuhde").Value == tyosuhde
                              select ele.Element("etunimi");
            //palautetaan lukumäärä
            return tyontekijat.Count();
        }
    }
}
