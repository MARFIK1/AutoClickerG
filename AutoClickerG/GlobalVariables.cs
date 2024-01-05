public static class GlobalVariables
{
    private static double coinBalance;

    public static double CoinBalance
    {
        get { return coinBalance; }
        set
        {
            coinBalance = value;
            OnCoinBalanceChanged?.Invoke(coinBalance);
        }
    }

    public static int ClickCounter { get; set; }

    public static event Action<double> OnCoinBalanceChanged;

    public static double ClickMultiplier { get; set; } = 1;
}