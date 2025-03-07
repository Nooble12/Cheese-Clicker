using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
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
    private PlayerData player;
    private ModifierManager modifiers = new ModifierManager();
    protected override void OnExit(ExitEventArgs e)
    {
        Debug.WriteLine("Game Closing");

        string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");

        PlayerDataSaver dataSaver = new();
        dataSaver.SavePlayerData(player, saveFolderPath, "GameSave");
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
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolder = Path.Combine(projectDirectory, "SaveFiles");

            string filePath = Path.Combine(saveFolder, "GameSave" + ".xml");
            PlayerDataLoader dataLoader = new PlayerDataLoader();
            player = dataLoader.LoadPlayerData(filePath);
        }
        else
        {
            player = new PlayerData(startingMoney, clickCount);
        }

        LauncherWindow launcher = new LauncherWindow(player, modifiers);
        launcher.Show();
    }
       
}
