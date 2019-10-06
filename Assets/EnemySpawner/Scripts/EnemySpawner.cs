using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnStart;
    private float spawnPointX;
    private float spawnPointY;
    private Vector2 spawnPosition;
    private int enemySpawned;

    void Awake()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {

        yield return new WaitForSeconds(spawnStart);

        while(enemySpawned < 30)
        {
        
            spawnPointX = Random.Range(-16, 6);
            spawnPointY = Random.Range(-8, 13);
            spawnPosition = new Vector2(spawnPointX, spawnPointY);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); 
            enemySpawned++;
            Debug.Log(enemySpawned);
            yield return new WaitForSeconds(spawnTime);

        }
    }
}
