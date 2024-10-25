using UnityEngine;

public class GameLevelManager : GameManager<int>
{
    public static GameLevelManager Instance => DerivedInstance<GameLevelManager>();

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetLevel(int level)
    {
        Set(level);
        GameEventManager.InvokeLevelUpdate(Value);  // 統括クラスを通じて通知
    }

    public void AddLevel(int level)
    {
        Add(level);
        GameEventManager.InvokeLevelUpdate(Value);  // 統括クラスを通じて通知
    }

    public void ResetLevel()
    {
        Reset();
        GameEventManager.InvokeLevelUpdate(Value);  // 統括クラスを通じて通知
    }
}
