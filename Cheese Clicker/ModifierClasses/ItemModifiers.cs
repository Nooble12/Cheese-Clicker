﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    [XmlInclude(typeof(CheeseItemModifier))]
    [XmlInclude(typeof(ComputerItemModifier))]
    public class ItemModifiers : Modifiers
    {
        [XmlElement("ModifierName")]
        private string modifierName = "N/A";

        [XmlElement("isModActive")]
        private Boolean isActive = false;
        [XmlElement("ModifierDuration")]
        private int duration = 0;
        [XmlElement("ModifierValue")]
        private int modifierValue = 0;
    }
}
