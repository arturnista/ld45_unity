using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bossPrefab;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject finishActivate;
    [SerializeField]
    private int enemyAmount;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnStart;
    private float spawnPointX;
    private float spawnPointY;
    private Vector2 spawnPosition;
    private int enemySpawned;
    
    private List<GameObject> enemiesSpawned;
    private PlayerHealth player;

    void Awake()
    {
        enemiesSpawned = new List<GameObject>();
        StartCoroutine(Spawn());
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {

        yield return new WaitForSeconds(spawnStart);

        while(enemySpawned < enemyAmount)
        {
        
            spawnPointX = Random.Range(-16, 6);
            spawnPointY = Random.Range(-8, 13);
            spawnPosition = new Vector2(spawnPointX, spawnPointY);

            if(Vector2.Distance(player.transform.position, spawnPosition) > 3f)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); 
                enemiesSpawned.Add(enemy);

                enemySpawned++;
                
                yield return new WaitForSeconds(spawnTime);
            }
            
        }

        while (true)
        {
            bool shouldSpawnBoss = true;
            foreach (var item in enemiesSpawned)
            {
                if(item != null)
                {
                    shouldSpawnBoss = false;
                    break;
                } 
            }    
            if(shouldSpawnBoss) break;

            yield return new WaitForSeconds(.2f);
        }

        yield return new WaitForSeconds(spawnStart);
        
        GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity); 

        while (boss != null)
        {
            yield return new WaitForSeconds(.2f);
        }

        finishActivate.SetActive(true);
    }
}
