using System;

public static class GameEventManager
{
    public static event Action<int> OnScoreUpdate;
    public static event Action<int> OnLevelUpdate;


    public static void InvokeScoreUpdate(int score)
    {
        OnScoreUpdate?.Invoke(score);
    }

    public static void InvokeLevelUpdate(int level)
    {
        OnLevelUpdate?.Invoke(level);
    }
}
