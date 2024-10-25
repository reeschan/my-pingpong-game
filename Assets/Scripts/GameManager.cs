using System;
using UnityEngine;

public interface IGameManager<T> where T : struct
{
    void Initialize();
    void Reset();
    void Add(T value);
}

public abstract class GameManager<T> : MonoBehaviour, IGameManager<T> where T : struct
{
    private static GameManager<T> Instance { get; set; }

    // 型指定された派生インスタンス
    protected static TDerived DerivedInstance<TDerived>() where TDerived : GameManager<T>
    {
        return Instance as TDerived;
    }

    public T Value { get; private set; }

    // ジェネリック型の更新イベント
    public static event Action<T> OnUpdated;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        Reset();
    }

    public void Reset()
    {
        Value = default;
        OnUpdated?.Invoke(Value);
    }

    public void Add(T value)
    {
        try
        {
            dynamic currentValue = Value;
            dynamic addedValue = value;
            Value = (T)(currentValue + addedValue);
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"Unsupported type for Add<T>: {typeof(T)} - {ex.Message}");
            return;
        }

        OnUpdated?.Invoke(Value);
    }

    public T Set(T value)
    {
        Value = value;
        OnUpdated?.Invoke(Value);
        return Value;
    }
}
