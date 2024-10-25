using UnityEngine;

public class GameScoreManager : GameManager<int>
{
    protected override void Awake()
    {
        base.Awake();
    }

    // スコアを直接設定するメソッド
    public void SetScore(int score)
    {
        Set(score);
        GameEventManager.InvokeScoreUpdate(Value);  // 統括クラスを通じて通知
    }

    // スコアを追加するメソッド
    public void AddScore(int points)
    {
        Add(points);
        GameEventManager.InvokeScoreUpdate(Value);  // 統括クラスを通じて通知
    }

    // スコアをリセットするメソッド
    public void ResetScore()
    {
        Reset();
        GameEventManager.InvokeScoreUpdate(Value);  // 統括クラスを通じて通知
    }
}
