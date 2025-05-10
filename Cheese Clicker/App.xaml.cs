using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SettingClasses;
using Cheese_Clicker.Utilities;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Cheese_Clicker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Player player;
    protected override void OnExit(ExitEventArgs e)
    {
        Debug.WriteLine("Game Closing");
        PlayerDataSaver dataSaver = new();
        dataSaver.SavePlayerData(player, "GameSave");

        SettingsSaver settingSaver = new SettingsSaver();
        settingSaver.SaveGameSettings();

        Debug.WriteLine(dataSaver.GetSavePath());
        base.OnExit(e);
    }

    public bool hasProfileInFile()
    {
        string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string saveFolder = Path.Combine(projectDirectory, "SaveFiles");
        if (!Directory.Exists(saveFolder))
        {
            return false;
        }

        string filePath = Path.Combine(saveFolder, "GameSave" + ".xml");
        if (File.Exists(filePath))
        {
            Debug.WriteLine("Profile Found");
            return true;
        }

        return false;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        if (hasProfileInFile())
        {
            PlayerDataLoader dataLoader = new PlayerDataLoader();

            SettingsLoader settingsLoader = new SettingsLoader();
            settingsLoader.LoadGameSettings();

            player = dataLoader.LoadPlayerGameState("GameSave.xml");
            //gameState.modifierManager.ReCalculateAllStats();
        }
        else
        {
            //Loads default values from DefaultGameConfig.json
            DefaultGameStatsLoader loader = new DefaultGameStatsLoader("DefaultGameConfig.json");
            DefaultStats stats = loader.GetDefaultStats();
            StatisticsManager statisitcsManager = new StatisticsManager(stats.startingMoney, stats.clickCount, stats.defaultMasteryRank, stats.totalMoneyGained);

            ModifierManager modifiers = new ModifierManager();
            Inventory playerInventory = new Inventory();

            player = new Player(statisitcsManager, modifiers, playerInventory);
        }

        LauncherWindow launcher = new LauncherWindow(player);
        launcher.Show();
    }
       
}
