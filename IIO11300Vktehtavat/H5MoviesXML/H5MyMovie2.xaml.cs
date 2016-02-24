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
using System.Xml;

namespace H5MoviesXML
{
    /// <summary>
    /// Interaction logic for H5MyMovie2.xaml
    /// </summary>
    public partial class H5MyMovie2 : Window
    {
        public H5MyMovie2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //tallennetaan muuttunut tieto XML_tiedostoon
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            if (lbMovies.SelectedIndex > -1)
            { 
            //lisäään xmlDocumenttiin uusi elementti
            //huom textboxit ja listboxit bindattu dataan
            lbMovies.SelectedIndex = -1;
            }
            {
                //lisätään uusi node
                string filu = xdpMovies.Source.LocalPath;
                //viittaus xmldokumenttiin ja sen juurielementtiin
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                //luodaan uusi node
                XmlNode newMovie = doc.CreateElement("Movie");
                //lisätään atribuutit
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = txtName.Text;
                newMovie.Attributes.Append(attr);
                XmlAttribute attr2 = doc.CreateAttribute("Director");
                attr2.Value = txtName.Text;
                newMovie.Attributes.Append(attr2);
                XmlAttribute attr3 = doc.CreateAttribute("Country");
                attr2.Value = txtName.Text;
                newMovie.Attributes.Append(attr3);
                root.AppendChild(newMovie);
                //tallennetaan filuun
                xdpMovies.Document.Save(filu);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //poistetaan valittu elementti xmlDocumentista
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
