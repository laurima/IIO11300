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

namespace H6DatabindingX3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //moduulitason muuttujat
        HockeyLeague smliiga;
        List<HockeyTeam> joukkueet;
        int clicked = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillMyComboBox();
            smliiga = new HockeyLeague();
            joukkueet = smliiga.getTeams();
        }
        private void FillMyComboBox()
        {
            cbCourses2.Items.Add("IIO12110 Ohjelmistotuotanto");
            cbCourses2.Items.Add("ZZ123 Helppoa Ruåtsia");
            cbCourses2.Items.Add("J2EE");
        }

        private void btnSetUser_Click(object sender, RoutedEventArgs e)
        {
            //luetaan App.Configista Username asetus
            txbUsername.Text = "Hello " + H6DatabindingX3.Properties.Settings.Default.Username;
        }

        private void cbCourses2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            myGrid.DataContext = joukkueet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            clicked++;
            myGrid.DataContext = joukkueet[clicked];
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            clicked--;
            myGrid.DataContext = joukkueet[clicked];
        }
    }
}
