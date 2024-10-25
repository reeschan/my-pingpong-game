using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{

    [SerializeField]
    private EnemyManager enemyManager;

    [SerializeField]
    private BallController ballController;

    [SerializeField]
    private GameOverMenuController gameOverMenuController;

    // Start is called before the first frame update
    void OnEnable()
    {
        BallController.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        BallController.OnGameOver -= GameOver;
    }

    void Update()
    {
        // xを押されたらreset
        if (Input.GetKeyDown(KeyCode.X))
        {
            ResetBallPosition();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameOverMenuController.isActiveAndEnabled)
            {
                gameOverMenuController.OnClose();
                StartGame();
            }
            ResetEnemy();
            ResetBallPosition();
        }
    }

    private void ResetBallPosition()
    {
        ballController.ResetBallPosition();
    }

    private void ResetEnemy()
    {
        enemyManager.ClearEnemies();
        enemyManager.SpawnEnemy();
        GameScoreManager.Instance.ResetScore();
    }

    public void GameOver()
    {
        gameOverMenuController.OnOpen();
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }
}
