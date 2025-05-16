using Cheese_Clicker.DeveloperTools;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    [XmlInclude(typeof(MultiplierModifier))]
    [XmlInclude(typeof(CriticalChanceModifier))]
    [XmlInclude(typeof(CriticalMultiplierModifier))]
    [XmlInclude(typeof(AdditiveModifier))]
    [XmlInclude(typeof(ItemModifiers))]
    [XmlType("Modifier")]
    public class Modifiers : ResultsDisplayable
    {
        [XmlElement("ModifierName")]
        public virtual string name { get; set; }

        [XmlElement("isModActive")]
        private Boolean isActive = false;
        [XmlElement("ModifierDuration")]
        private int duration = 0;
        [XmlElement("ModifierValue")]
        private int modifierValue = 0;

        public virtual int GetModifierValue()
        {
            return modifierValue;
        }

        public string GetDisplayInfo()
        {
            return name;
        }
    }
}
