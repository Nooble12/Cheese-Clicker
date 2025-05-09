﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.ModifierClasses
{
    public class CheeseItemModifier : ItemModifiers
    {
        private string name = "Cheese Item Multiplier Modifier";
        private int multiplierValue = 4; // 2 times
        private int duration = 10; // clicks

        public override int GetModifierValue()
        {
            return multiplierValue;
        }

        public string GetModifierName()
        {
            return name;
        }

        public int GetDurationName()
        {
            return duration;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name + ": ");
            builder.AppendLine("+ " + multiplierValue + "x");
            return builder.ToString();
        }
    }
}
