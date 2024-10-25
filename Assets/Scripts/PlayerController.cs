using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float speedMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.A) && transform.position.x > -4.0f)
        {
            newPosition += Vector3.left * speed * Time.deltaTime * (isShiftPressed ? speedMultiplier : 1.0f);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 4.0f)
        {
            newPosition += Vector3.right * speed * Time.deltaTime * (isShiftPressed ? speedMultiplier : 1.0f);
        }
        transform.position = newPosition;
    }
}
