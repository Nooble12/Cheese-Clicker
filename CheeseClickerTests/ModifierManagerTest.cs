using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;

namespace CheeseClickerTests
{
    public class ModifierManagerTest
    {
        [Fact]
        public void Multiplier_Modifier()
        {
            // Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            manager.SetCriticalChance(0);
            Modifiers modifier = new MultiplierModifier();
            
            // Act
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            // Assert
            Assert.Equal(400, newMoneyValue);
        }

        [Fact]
        public void Additive_Modifier()
        {
            // Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            manager.SetCriticalChance(0);
            Modifiers modifier = new AdditiveModifier();

            // Act
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            manager.AddModifier(modifier);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            // Assert
            Assert.Equal(500, newMoneyValue);
        }

        [Fact]
        public void Add_And_Multiply_Modifiers()
        {
            // Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            manager.SetCriticalChance(0);
            Modifiers addMod = new AdditiveModifier();
            Modifiers multiplyMod = new MultiplierModifier();

            // Act
            manager.AddModifier(addMod);
            manager.AddModifier(addMod);
            manager.AddModifier(multiplyMod);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            // Assert
            Assert.Equal(600, newMoneyValue);

        }

        [Fact]
        public void Max_Normal_Critical_Chance_Modifier()
        {
            //Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalChanceMod = new CriticalChanceModifier();
            manager.SetCriticalChance(0); // reset the innate 10 percent to zero for easy testing

            // Act
            manager.AddModifier(criticalChanceMod); // 20 percent each mod
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            manager.AddModifier(criticalChanceMod);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;
            CriticalType actualCritType = reward.criticalType;

            CriticalType expectedCritType = CriticalType.Critical;
            // Assert
            Assert.Equal(200, newMoneyValue);
            Assert.Equal(expectedCritType, actualCritType);
        }

        [Fact]
        public void Super_Critical_Chance_Modifier()
        {
            //Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalChanceMod = new CriticalChanceModifier();
            manager.SetCriticalChance(200); // 100 percent to super crit

            // Act
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;
            CriticalType actualCritType = reward.criticalType;

            CriticalType expectedCritType = CriticalType.SuperCritical;

            //Assert
            Assert.Equal(400, newMoneyValue);
            Assert.Equal(expectedCritType, actualCritType);
        }

        [Fact]
        public void Critical_Multiplier()
        {
            //Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(100);

            //Act
            manager.AddModifier(criticalMultiplyMod);
            manager.AddModifier(criticalMultiplyMod);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            //Assert
            Assert.Equal(600, newMoneyValue);
        }

        [Fact]
        public void Super_Critical_Multiplier()
        {
            //Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(200);

            //Act
            manager.AddModifier(criticalMultiplyMod);
            manager.AddModifier(criticalMultiplyMod);
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            //Assert
            Assert.Equal(1200, newMoneyValue);
        }

        [Fact]
        public void Crit_Chance_Beyond_300_Percent()
        {
            //Arrange
            long money = 100;
            ModifierManager manager = new ModifierManager();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            manager.SetCriticalChance(350);

            //Act
            Reward reward = manager.ApplyAllModifiers(money);
            long newMoneyValue = reward.moneyGained;

            //Assert
            Assert.Equal(600, newMoneyValue);
        }
    }
}
