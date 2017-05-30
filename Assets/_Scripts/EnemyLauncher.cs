using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{

    public float fireRate = 5f;
    public GameObject enemyPrefab;
    public List<GameObject> enemies;

    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFire)
        {
            this.LaunchEnemy();
            //this.CalculateCameras();
        }
    }

    private void LaunchEnemy()
    {
        GameObject enemy;
        Vector3 spawnPosition = this.RandomCircle(transform.position, 35f);
        nextFire = Time.time + fireRate;
        enemy = Instantiate(enemyPrefab, spawnPosition, transform.rotation);
        enemies.Add(enemy);
    }

    private void CalculateCameras() {

        if (enemies.Count == 1)
        {
            return;
        }

        if (enemies.Count == 2)
        {
            enemies[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
            enemies[1].GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
            return;
        }

        float gridSize = (enemies.Count % 2 == 0) ? enemies.Count : enemies.Count + 1;
        gridSize *= 0.5f;
        float cellSize = 1 / gridSize;

        int count = 0;
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                enemies[count].GetComponentInChildren<Camera>().rect = new Rect(x * cellSize, y * cellSize, cellSize, cellSize);
                if (++count == enemies.Count)
                {
                    return;
                }
            }
        }

    }

    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360f;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + 0.5f;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
