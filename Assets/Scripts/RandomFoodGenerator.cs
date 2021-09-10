using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodGenerator : MonoBehaviour
{

    Vector3 Center;
    Vector3 size;
   [SerializeField] List<GameObject> Food;
    int i;
    [SerializeField]float SpawnTime = 4f;
    float Spantimer=0f;
    [SerializeField] GameObject Enemy;
    float EnemySpawnTimer, enemySpawn = 6f;
  

    // Start is called before the first frame update
    void Start()
    {
        Center = transform.position;
        size = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        Spantimer += Time.deltaTime;

        if (Spantimer > SpawnTime)
        {
            spawnFood();
            spawnFood();
            spawnFood();
            spawnFood();
            Spantimer = 0f;

        }

        EnemySpawnTimer += Time.deltaTime;
        if (EnemySpawnTimer > enemySpawn)
        {

            spawnEnemy();

            EnemySpawnTimer = 0f;
            
        }

        
    }

    void spawnFood()
    {
        Vector3 pos = Center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y/8, size.y/8), Random.Range(-size.z / 2, size.z/2));
        i = Random.Range(0, 8);
        Instantiate(Food[i], pos, Quaternion.identity);

    }

    void spawnEnemy()
    {

        Vector3 pos = Center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 8, size.y / 8), Random.Range(-size.z / 2, size.z / 2));
        i = Random.Range(0, 8);
        Instantiate(Enemy, pos, Quaternion.identity);

    }


}
