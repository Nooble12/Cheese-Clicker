using Cheese_Clicker.ModifierClasses;
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

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for AdminControlPage.xaml
    /// </summary>
    public partial class AdminControlPage : Page
    {
        private ModifierManager modifierManager;
        public AdminControlPage(ModifierManager inManager)
        {
            InitializeComponent();
            modifierManager = inManager;
        }

        private void GiveMultiplyMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers multiplyMod = new MultiplierModifier();
            modifierManager.AddModifier(multiplyMod);
        }

        private void GiveAddMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new AdditiveModifier();
            modifierManager.AddModifier(modAdd);
        }
        private void GiveCritChance_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalChanceModifier();
            modifierManager.AddModifier(modAdd);
        }
        private void GiveCritMultiply_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalMultiplierModifier();
            modifierManager.AddModifier(modAdd);
        }
        private void ClearAllMods_Click(object sender, RoutedEventArgs e)
        {
            modifierManager.ClearAllModifiers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
