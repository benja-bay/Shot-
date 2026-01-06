public class PlayerStats
{
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void LoseLife(int amount = 1)
    {
        Lives -= amount;
    }

    public bool IsDead => Lives <= 0;
}