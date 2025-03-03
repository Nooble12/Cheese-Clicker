using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
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
            manager.SetCriticalChance(0);
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
            manager.SetCriticalChance(0);
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
            manager.SetCriticalChance(0);
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

        [Fact]
        public void Max_Normal_Critical_Chance_Modifier()
        {
            //Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalChanceMod = new CriticalChanceModifier();
            manager.SetCriticalChance(0); // reset the innate 10 percent to zero for easy testing

            // Act
            manager.AddModifier(criticalChanceMod); // 20 percent each mod
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            // Assert
            Assert.Equal(200, newMoneyValue);
        }

        [Fact]
        public void Super_Critical_Chance_Modifier()
        {
            //Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalChanceMod = new CriticalChanceModifier();
            manager.SetCriticalChance(200); // 100 percent to super crit

            // Act
            int newMoneyValue = manager.ApplyAllModifiers(money);

            //Assert
            Assert.Equal(400, newMoneyValue);
        }

        [Fact]
        public void Critical_Multiplier()
        {
            //Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(100);

            //Act
            manager.AddModifier(criticalMultiplyMod);
            manager.AddModifier(criticalMultiplyMod);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            //Assert
            Assert.Equal(600, newMoneyValue);
        }

        [Fact]
        public void Super_Critical_Multiplier()
        {
            //Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(200);

            //Act
            manager.AddModifier(criticalMultiplyMod);
            manager.AddModifier(criticalMultiplyMod);
            int newMoneyValue = manager.ApplyAllModifiers(money);

            //Assert
            Assert.Equal(1200, newMoneyValue);
        }

        [Fact]
        public void Crit_Chance_Beyond_300_Percent()
        {
            //Arrange
            int money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(350);

            //Act
            int newMoneyValue = manager.ApplyAllModifiers(money);

            //Assert
            Assert.Equal(600, newMoneyValue);
        }
    }
}
