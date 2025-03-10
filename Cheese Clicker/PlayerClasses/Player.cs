using Cheese_Clicker.ModifierClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.PlayerClasses
{
    public class Player
    {
        public StatisitcsManager statistics { get; set; }
        public ModifierManager modifierManager { get; set; }
        public Inventory inventory { get; set; }
        public Player(StatisitcsManager inStatsManager, ModifierManager inModifiers, Inventory inInventory)
        {
            statistics = inStatsManager;
            modifierManager = inModifiers;
            inventory = inInventory;
        }

        public Player()
        {
            statistics = new StatisitcsManager();
            modifierManager = new ModifierManager();
            inventory = new Inventory();
        }
    }
}
