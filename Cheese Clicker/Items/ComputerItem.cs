﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.Items
{
   public class ComputerItem : Item
    {
        [XmlElement("ItemName")]
        public override string name { get; set; } = "Computer";

        [XmlElement("ItemDescription")]
        public override string description { get; set; } = "A computer";

        [XmlElement("ItemPurchasePrice")]
        public override int purchasePrice { get; set; } = 2000;

        [XmlElement("ItemSellPrice")]
        public override int sellPrice { get; set; } = 1000;
    }
}
