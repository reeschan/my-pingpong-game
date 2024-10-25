using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
    }
}
