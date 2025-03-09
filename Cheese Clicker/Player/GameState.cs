using Cheese_Clicker.ModifierClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.Player
{
    public class GameState
    {
        public PlayerData playerData { get; set; }
        public ModifierManager modifierManager { get; set; }
        public Inventory playerInventory { get; set; }
        public GameState(PlayerData inPlayer, ModifierManager inModifiers, Inventory inInventory)
        {
            playerData = inPlayer;
            modifierManager = inModifiers;
            playerInventory = inInventory;
        }

        public GameState()
        {
            playerData = new PlayerData();
            modifierManager = new ModifierManager();
            playerInventory = new Inventory();
        }
    }
}
