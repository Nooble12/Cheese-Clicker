using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
using Cheese_Clicker.PlayerClasses;

namespace Cheese_Clicker
{
    /// <summary>
    /// Interaction logic for LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {
        public LauncherWindow(Player inPlayer)
        {
            InitializeComponent();
            LauncherWin.Visibility = Visibility.Visible;
            LauncherWin.Navigate(new LauncherPage(inPlayer, this));
        }
    }
}