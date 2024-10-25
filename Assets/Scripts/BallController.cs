using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;

    [SerializeField]
    public GameObject player;

    [HideInInspector]
    private Rigidbody rb;

    [HideInInspector]
    public static event Action OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InitForce();
    }

    public void InitForce()
    {
        rb.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // スピードが常に一定になるようにする
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagHelper.GetTagName(Tag.Player))
        {
            // プレイヤーとの衝突処理
            GameObject playerObject = collision.gameObject;
            BoxCollider playerCollider = playerObject.GetComponent<BoxCollider>();

            float hitPosition = (this.transform.position.x - playerObject.transform.position.x) / (playerCollider.size.x / 2);
            float currentSpeed = rb.velocity.magnitude;
            float bounceAngle = hitPosition * 20f * Mathf.Deg2Rad;

            Vector3 newVelocity = new Vector3(Mathf.Sin(bounceAngle), rb.velocity.y, Mathf.Cos(bounceAngle)) * currentSpeed;

            // 水平に近い入射角の場合、上下にy軸方向の力を加える
            if (Mathf.Abs(Mathf.Cos(bounceAngle)) < 0.1f)
            {
                if (rb.velocity.y > 0)
                {
                    newVelocity.y = -Mathf.Abs(rb.velocity.y); // 上から来た場合
                }
                else
                {
                    newVelocity.y = Mathf.Abs(rb.velocity.y);  // 下から来た場合
                }
            }

            rb.velocity = newVelocity;
        }
        else if (collision.gameObject.tag == TagHelper.GetTagName(Tag.Wall))
        {
            Vector3 newVelocity = rb.velocity;

            // 水平移動が発生している場合の判定
            if (Mathf.Abs(newVelocity.x) > Mathf.Abs(newVelocity.z) * 0.9f) // 水平に近いと判断
            {
                // 上下方向に力を加える。入射角に基づきz方向の速度を調整
                if (newVelocity.z == 0)
                {
                    newVelocity.z = (newVelocity.x > 0) ? -Mathf.Abs(newVelocity.magnitude * 0.5f) : Mathf.Abs(newVelocity.magnitude * 0.5f);
                }
                else
                {
                    // すでにz方向に速度がある場合も、少し調整を加える
                    newVelocity.z = (newVelocity.z > 0) ? Mathf.Abs(newVelocity.z) : -Mathf.Abs(newVelocity.z);
                }
            }

            // 新しい速度を適用
            rb.velocity = newVelocity.normalized * speed;
        }
        else if (collision.gameObject.tag == TagHelper.GetTagName(Tag.GameOverZone))
        {
            OnGameOver?.Invoke();
        }
    }


    public void ResetBallPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, 0.5f, 0);
        InitForce();
    }
}
