using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject prefab;
    public float respawnTime = 5f;
    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject platform = Instantiate(prefab) as GameObject;
        platform.transform.position = new Vector2(20, Random.Range(-2, 1));
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
