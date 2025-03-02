using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cheese_Clicker.ModifierClasses
{
    public class Modifiers
    {
        private string modifierName = "N/A";
        private Boolean isActive = false;
        private int duration = 0;
        private int modifierValue = 0;

        public virtual int GetModifierValue()
        {
            return modifierValue;
        }
    }
}
