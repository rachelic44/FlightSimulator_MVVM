﻿using FlightSimulator.Model;
using FlightSimulator.ViewModels;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for JoysticNew.xaml
    /// </summary>
    public partial class Manual : UserControl
    {
        private ManualViewModel vm;
        public Manual()
        {
            this.vm = new ManualViewModel(new ManualModel());
            InitializeComponent();
            DataContext = vm;

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}