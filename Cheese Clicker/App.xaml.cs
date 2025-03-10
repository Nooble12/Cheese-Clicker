using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Windows;
using Cheese_Clicker.PlayerClasses;

namespace Cheese_Clicker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private long startingMoney = 1000L;
    private int clickCount = 0;

    private Player player;
    protected override void OnExit(ExitEventArgs e)
    {
        Debug.WriteLine("Game Closing");
        PlayerDataSaver dataSaver = new();
        dataSaver.SavePlayerData(player, "GameSave");
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

            player = dataLoader.LoadPlayerGameState("GameSave.xml");
            //gameState.modifierManager.ReCalculateAllStats();
        }
        else
        {
            StatisitcsManager statisitcsManager = new StatisitcsManager(startingMoney, clickCount);
            ModifierManager modifiers = new ModifierManager();
            Inventory playerInventory = new Inventory();

            player = new Player(statisitcsManager, modifiers, playerInventory);
        }

        LauncherWindow launcher = new LauncherWindow(player);
        launcher.Show();
    }
       
}
