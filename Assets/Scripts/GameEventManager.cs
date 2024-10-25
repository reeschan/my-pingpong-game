using System;

public static class GameEventManager
{
    public static event Action<int> OnScoreUpdate;
    public static event Action<int> OnDifficultyUpdate;

    public static void InvokeScoreUpdate(int score)
    {
        OnScoreUpdate?.Invoke(score);
    }

    public static void InvokeDifficultyUpdate(int difficulty)
    {
        OnDifficultyUpdate?.Invoke(difficulty);
    }
}
