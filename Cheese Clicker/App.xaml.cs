using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.Player;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Windows;

namespace Cheese_Clicker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private long startingMoney = 1000L;
    private int clickCount = 0;

    private GameState gameState;
    protected override void OnExit(ExitEventArgs e)
    {
        Debug.WriteLine("Game Closing");
        PlayerDataSaver dataSaver = new();
        dataSaver.SavePlayerData(gameState, "GameSave");
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

            gameState = dataLoader.LoadPlayerGameState("GameSave.xml");
            //gameState.modifierManager.ReCalculateAllStats();
        }
        else
        {
            PlayerData player = new PlayerData(startingMoney, clickCount);
            ModifierManager modifiers = new ModifierManager();
            Inventory playerInventory = new Inventory();

            gameState = new GameState(player, modifiers, playerInventory);
        }

        LauncherWindow launcher = new LauncherWindow(gameState);
        launcher.Show();
    }
       
}
