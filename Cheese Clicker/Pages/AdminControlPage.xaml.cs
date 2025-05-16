using Cheese_Clicker.DeveloperTools;
using Cheese_Clicker.Items;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for AdminControlPage.xaml
    /// </summary>
    public partial class AdminControlPage : Page
    {
        private Player player;
        private string searchBoxString;
        private bool searchForItem = true;
        private bool searchForModifier = false;

        private List<ResultsDisplayable> objectList = new List<ResultsDisplayable>
        {
            new CheeseItem(),
            new ComputerItem(),
            new MultiplierModifier(),
            new CriticalChanceModifier(),
            new AdditiveModifier(),
            new CriticalMultiplierModifier()
        };

        public ObservableCollection<ResultsDisplayable> ResultsList { get; set; } = new ObservableCollection<ResultsDisplayable>();

        public AdminControlPage(Player inGameState)
        {
            InitializeComponent();
            player = inGameState;
            SearchBox.Text = "";
            ResultsListBox.ItemsSource = ResultsList;
            UpdateUI();
        }

        private void ClearAllMods_Click(object sender, RoutedEventArgs e)
        {
            player.modifierManager.ClearAllModifiers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UpdateUI()
        {
            //Assigns the button colors
            if (PlayerMoneyGrid.Visibility == Visibility.Visible)
            {
                PlayerStatsButton.Background = Brushes.LightGreen;
                ItemAndModifierButton.Background = Brushes.Gray;
            }
            else
            {
                PlayerStatsButton.Background = Brushes.Gray;
                ItemAndModifierButton.Background = Brushes.LightGreen;
            }
        }

        private void SearchForInput(string inString)
        {
            string processedString = inString.ToLower().Trim();
            foreach (var result in objectList)
            {
                switch (result)
                {
                    case Item item:
                        if (item.name.IndexOf(processedString, StringComparison.OrdinalIgnoreCase) >= 0 || "item".IndexOf(processedString, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            ResultsList.Add(item);
                        }
                        break;

                    case Modifiers modifier:
                        if (modifier.name.IndexOf(processedString, StringComparison.OrdinalIgnoreCase) >= 0 || "modifier".IndexOf(processedString, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            ResultsList.Add(modifier);
                        }
                        break;

                    default:
                        Debug.WriteLine("Could not find item / modifier");
                    break;
                }
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResultsList.Clear();
            searchBoxString = SearchBox.Text;
            SearchForInput(searchBoxString);

            //So program does not crash when you first open the page as ResultsFoundLabel as not been loaded yet.
            if (ResultsFoundLabel != null)
            {
                ResultsFoundLabel.Content = "Results Found: " + ResultsList.Count;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var instance = button.DataContext;
                switch(instance)
                {
                    case Item item:
                        player.inventory.AddItem(item, 1);
                    break;

                    case Modifiers modifier:
                        player.modifierManager.AddModifier(modifier);
                    break;
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var instance = button.DataContext;
                switch (instance)
                {
                    case Item item:
                        player.inventory.RemoveItem(item, 1);
                    break;

                        //TODO: Add code to remove single modifiers. Need to rework modifier system before this can be done.
                    case Modifiers modifier:
                        //player.modifierManager.RemoveModifier(modifier);
                    break;
                }
            }
        }

        private void PlayerStatsButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerStatsButton.Background = Brushes.LightGreen;
            ItemAndModifierButton.Background = Brushes.Gray;
            ModifierAndItemGrid.Visibility = Visibility.Collapsed;
            PlayerStatsGrid.Visibility = Visibility.Visible;
        }

        private void ItemAndModifierButton_Click(object sender, RoutedEventArgs e)
        {
            ItemAndModifierButton.Background = Brushes.LightGreen;
            PlayerStatsButton.Background = Brushes.Gray;
            ModifierAndItemGrid.Visibility = Visibility.Visible;
            PlayerStatsGrid.Visibility = Visibility.Collapsed;
        }

        //Code For Player Statistics Grid
        StringBuilder changeLogStringBuilder = new StringBuilder();
        private void ApplyMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            string moneyTextBoxContent = SetMoneyTextBox.Text;
            long originalMoney = player.statistics.money;

            if (long.TryParse(moneyTextBoxContent, out long newMoneyValue))
            {
                player.statistics.money = newMoneyValue;
                SetTextBoxColor(SetMoneyTextBox, Brushes.LightGreen);
                AppendChangeLogTextBox("Changed $" + originalMoney + " -> $" + newMoneyValue);
            }
            else
            {
                SetMoneyTextBox.Text = "Error, invalid integer.";
                SetTextBoxColor(SetMoneyTextBox, Brushes.Red);
            }
        }
        private void ApplyMasteryRank_Click(object sender, RoutedEventArgs e)
        {
            string masteryRankTextBoxContents = SetMasteryRankTextBox.Text;
            short originalMasteryRank = player.statistics.masteryRankLevel;

            if (short.TryParse(masteryRankTextBoxContents, out short newMasteryRank))
            {
                player.statistics.masteryRankLevel = newMasteryRank;
                SetTextBoxColor(SetMasteryRankTextBox, Brushes.LightGreen);
                AppendChangeLogTextBox("Changed MR: " + originalMasteryRank + " -> " + newMasteryRank);
            }
            else
            {
                SetMasteryRankTextBox.Text = "Error, invalid short integer.";
                SetTextBoxColor(SetMasteryRankTextBox, Brushes.Red);
            }
        }

        private void AppendChangeLogTextBox(string inString)
        {
            changeLogStringBuilder.AppendLine(inString);
            ChangeLogTextBox.Text = changeLogStringBuilder.ToString();
        }
        private void SetMoneyTextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetMoneyTextBox.Text = "";
        }

        private void SetMasteryRankTextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetMasteryRankTextBox.Text = "";
        }

        private void SetTextBoxColor(TextBox box, Brush color)
        {
            box.Background = color;
        }

        private void ApplyClickCountButton_Click(object sender, RoutedEventArgs e)
        {
            string setClickCountButtonText = SetClickCountButton.Text;
            int originalClickCount = player.statistics.clickCount;

            if (int.TryParse(setClickCountButtonText, out int newClickCount))
            {
                player.statistics.clickCount = newClickCount;
                SetTextBoxColor(SetClickCountButton, Brushes.LightGreen);
                AppendChangeLogTextBox("Changed Click Count: " + originalClickCount + " -> " + newClickCount);
            }
            else
            {
                SetClickCountButton.Text = "Error, invalid integer.";
                SetTextBoxColor(SetClickCountButton, Brushes.Red);
            }
        }

        private void SetClickCountButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetClickCountButton.Text = "";
        }
    }
}
