﻿using System.Text;

namespace Cheese_Clicker.ModifierClasses
{
    public class MultiplierModifier : Modifiers
    {
        private string name = "Multiplier Modifier";
        private int multiplierValue = 2; // 2 times
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
