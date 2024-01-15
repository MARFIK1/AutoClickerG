using AutoClickerG;

public static class GlobalVariables
{
    private static double coinBalance;

    public static double CoinBalance
    {
        get { return coinBalance; }
        set
        {
            coinBalance = Math.Truncate(value * 10000) / 10000;
            OnCoinBalanceChanged?.Invoke(coinBalance);
        }
    }

    private static int diamondBalance;

    public static int DiamondBalance
    {
        get { return diamondBalance; }
        set
        {
            diamondBalance = value;
            OnDiamondBalanceChanged?.Invoke(diamondBalance);
        }
    }

    public static int ClickCounter { get; set; }

    public static event Action<double> OnCoinBalanceChanged;
    public static event Action<int> OnDiamondBalanceChanged;

    public static double ClickMultiplier { get; set; } = 1;
    public static double DiamondChance { get; set; } = 1;
    public static int DiamondMultiplier { get; set; } = 1;
    public static double AutoClickerValue { get; set; } = 0;
    public static double ClickComboMultiplier { get; set; } = 0;
    public static int BalanceDoublerTimer { get; set; } = 0;
    public static int IsBalanceDoublerBought { get; set; } = 0;
    public static int DiamondRushTimer { get; set; } = 0;
    public static int IsDiamondRushBought { get; set; } = 0;
    public static bool IsDiamondRushActive { get; set; } = false;
    public static double TotalCoinsEarned = 0;
    public static double TotalDiamondsEarned = 0;
    public static double HighestClickMultiplier = 1;

    public static List<Achievement> Achievements = new List<Achievement>
    {
        new Achievement("First Step - Earn your first coin.", 1, 1, "Coins"),                    
        new Achievement("Gold Stream - Earn 10 coins.", 10, 3, "Coins"),
        new Achievement("Gold Rain - Earn 100 coins.", 100, 5, "Coins"),
        new Achievement("Gold Tsunami - Earn 500 coins.", 500, 10, "Coins"),
        new Achievement("Midas Wealth - Earn 1000 coins.", 1000, 50, "Coins"),
        new Achievement("First Diamond - Earn your first diamond.", 1, 20, "Coins"),
        new Achievement("Diamond Rain - Earn 10 diamonds.", 10, 100, "Coins"),
        new Achievement("Diamond Avalanche - Earn 50 diamonds.", 50, 300, "Coins"),
        new Achievement("Diamond Crown - Earn 100 diamonds.", 100, 1000, "Coins"),
        new Achievement("First Click - Make your first click.", 1, 1, "Coins"),
        new Achievement("Engaged Player - Make 50 clicks.", 50, 20, "Coins"),
        new Achievement("Click Master - Make 100 clicks.", 100, 30, "Coins"),
        new Achievement("Fortuna Goddess - Make 500 clicks.", 500, 50, "Coins"),
        new Achievement("Combo Beginner - Achieve 3x combo multiplier.", 3, 5, "Diamonds", 1),
        new Achievement("Combo Master - Achieve 5x combo multiplier.", 5, 10, "Diamonds", 1),
        new Achievement("Combo God - Achieve 10x combo multiplier.", 10, 50, "Diamonds", 1),
        new Achievement("Balance Doubler - Use Balance Doubler for the first time.", 1, 10, "Diamonds"),
        new Achievement("Balance Multiplier - Use Balance Doubler 3 times.", 3, 25, "Diamonds"),
        new Achievement("Diamond Rush - Use Diamond Rush for the first time.", 1, 10, "Diamonds"),
        new Achievement("Diamond Multiplier - Use Diamond Rush 3 times.", 3, 25, "Diamonds"),
        new Achievement("Upgrade Enthusiast - Purchase 5 upgrades.", 5, 10, "Diamonds"),
        new Achievement("Upgrade Collector - Purchase 10 upgrades.", 10, 30, "Diamonds"),
        new Achievement("Upgrade Hoarder - Purchase 20 upgrades.", 20, 100, "Diamonds"),
        new Achievement("Category Master - Fully upgrade a category.", 1, 20, "Diamonds"),
        new Achievement("Category God - Fully upgrade 3 categories.", 3, 200, "Diamonds"),
        new Achievement("Time Tracker - Play for 1 minute.", 60, 1, "Coins"),
        new Achievement("Time Lord - Play for 2 minutes.", 120, 3, "Coins"),
        new Achievement("Time God - Play for 3 minutes.", 180, 7, "Coins"),
        new Achievement("Achievement Collector - Collect all other achievements.", 28, 1000, "Diamonds")
    };

    public static List<string> PurchasedItems { get; set; } = new List<string> { "Coin" };
    public static string SelectedItem { get; set; } = "Coin";
}