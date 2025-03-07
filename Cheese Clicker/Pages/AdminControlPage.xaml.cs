using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.Player;
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
        private GameState gameState;
        public AdminControlPage(GameState inGameState)
        {
            InitializeComponent();
            gameState = inGameState;
        }

        private void GiveMultiplyMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers multiplyMod = new MultiplierModifier();
            gameState.modifierManager.AddModifier(multiplyMod);
        }

        private void GiveAddMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new AdditiveModifier();
            gameState.modifierManager.AddModifier(modAdd);
        }
        private void GiveCritChance_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalChanceModifier();
            gameState.modifierManager.AddModifier(modAdd);
        }
        private void GiveCritMultiply_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalMultiplierModifier();
            gameState.modifierManager.AddModifier(modAdd);
        }
        private void ClearAllMods_Click(object sender, RoutedEventArgs e)
        {
            gameState.modifierManager.ClearAllModifiers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
