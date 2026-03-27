using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    void Start()
    {
        //InvokeRepeating(nameof(RandomSpawn),0,3);
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            RandomSpawn();
            yield return new  WaitForSeconds(3);
        }
    }
    void RandomSpawn()
    {
        var index = Random.Range(0,spawnPoints.Length);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity);
    }
}
