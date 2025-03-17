using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    [XmlInclude(typeof(MultiplierModifier))]
    [XmlInclude(typeof(CriticalChanceModifier))]
    [XmlInclude(typeof(CriticalMultiplierModifier))]
    [XmlInclude(typeof(AdditiveModifier))]
    [XmlInclude(typeof(ItemModifiers))]
    [XmlType("Modifier")]
    public class Modifiers
    {
        [XmlElement("ModifierName")]
        private string modifierName = "N/A";

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
    }
}
