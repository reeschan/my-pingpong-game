using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    public int spawnEnemyCount;

    [HideInInspector]
    public int currentEnemyCount;

    private GameObject enemyPrefab;


    void OnEnable()
    {
        EnemyController.OnDeleteEnemy += this.OnEnemyDeleted;
    }

    void OnDisable()
    {
        EnemyController.OnDeleteEnemy -= this.OnEnemyDeleted;
    }

    void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        this.currentEnemyCount = this.spawnEnemyCount;
        SpawnEnemy();
    }

    void Update()
    {
    }

    public int GetEnemyCount()
    {
        return currentEnemyCount;
    }

    public void SpawnEnemy()
    {
        this.currentEnemyCount = this.spawnEnemyCount;
        float maxX = this.transform.localScale.x / 2;
        float maxZ = this.transform.localScale.z / 2;
        float offsetX = this.transform.position.x;
        float offsetZ = this.transform.position.z;
        for (int i = 0; i < currentEnemyCount; i++)
        {
            float x = Random.Range(-maxX, maxX) + offsetX;
            float z = Random.Range(-maxZ, maxZ) + offsetZ;
            Vector3 position = new Vector3(x, 0.5f, z);
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }
    void OnEnemyDeleted(int points)
    {
        this.currentEnemyCount--;
        GameScoreManager.Instance.AddScore(points);
        Debug.Log("OnDeleteEnemy: " + this.currentEnemyCount);
    }

    public void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Resources.UnloadUnusedAssets();
        this.currentEnemyCount = spawnEnemyCount;
    }
}
