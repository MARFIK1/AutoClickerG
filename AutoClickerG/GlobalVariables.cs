public static class GlobalVariables
{
    private static double coinBalance;

    public static double CoinBalance
    {
        get { return coinBalance; }
        set
        {
            coinBalance = Math.Round(value, 3);
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
}