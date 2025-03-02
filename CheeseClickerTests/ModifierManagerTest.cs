using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheese_Clicker;
using Cheese_Clicker.ModifierClasses;

namespace CheeseClickerTests
{
    public class ModifierManagerTest
    {
        [Fact]
        public void Multiplier_Modifier()
        {
            // Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers modifier = new MultiplierModifier();
            
            // Act
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            // Assert
            Assert.Equal(400, newMoneyValue);
        }

        [Fact]
        public void Additive_Modifier()
        {
            // Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers modifier = new AdditiveModifier();

            // Act
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            // Assert
            Assert.Equal(500, newMoneyValue);
        }

        [Fact]
        public void Add_And_Multiply_Modifiers()
        {
            // Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers addMod = new AdditiveModifier();
            Modifiers multiplyMod = new MultiplierModifier();

            // Act
            manager.AddModifier(addMod);
            manager.AddModifier(addMod);
            manager.AddModifier(multiplyMod);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            // Assert
            Assert.Equal(600, newMoneyValue);

        }
    }
}
