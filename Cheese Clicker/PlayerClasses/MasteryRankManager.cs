namespace Cheese_Clicker.PlayerClasses
{
    public class MasteryRankManager
    {
        private Player player;
        public MasteryRankManager(Player inPlayer)
        {
            player = inPlayer;
        }
        public bool CheckMasteryRankEligibility()
        {
            if (player.statistics.money >= GetMasteryRankEligibilityRequirement())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public long GetMasteryRankEligibilityRequirement()
        {  
            long baseMasteryRankRequirement = 1000000; // To rank up to level 2
            return (long) Math.Floor((Math.Pow(player.statistics.masteryRankLevel, 2) / 10.0) * baseMasteryRankRequirement);
        }

        public float GetMasteryRankPercent()
        {
            float percent = ((float)player.statistics.money / GetMasteryRankEligibilityRequirement()) * 100.0f;
            return percent;
        }

        public void RankUpMastery()
        {
            player.statistics.IncrementMasteryRankLevel();
            player.statistics.ResetMoney();
            player.modifierManager.ResetAllItemModifiers();
            player.inventory.ClearInventory();
            player.modifierManager.AddRandomModifier();
        }
    }
}
