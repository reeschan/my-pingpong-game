using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class IEnemyController : MonoBehaviour
{
    [SerializeField]
    public int Score = 0;

    [SerializeField]
    public int hitPoint = 0;

    // 敵が消滅するときに発火するイベント
    public static event Action<int> OnDeleteEnemy;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagHelper.GetTagName(Tag.Ball))
        {
            Destroy(this.gameObject);

            // イベントを発火して他のスクリプトに通知
            OnDeleteEnemy?.Invoke(this.Score);
        }
    }
}
