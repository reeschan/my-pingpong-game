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
    public static GameManager<T> Instance { get; private set; }

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
        if (typeof(T) == typeof(int))
        {
            Value = (T)(object)((int)(object)Value + (int)(object)value);
        }
        else if (typeof(T) == typeof(float))
        {
            Value = (T)(object)((float)(object)Value + (float)(object)value);
        }
        else
        {
            Debug.LogWarning("Unsupported type for Add<T>: " + typeof(T));
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
