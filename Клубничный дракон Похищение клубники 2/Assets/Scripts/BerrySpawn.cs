using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySpawn : MonoBehaviour
{
    PointManager pointManager;

    public GameObject[] berries;
    public GameObject[] bigBerries;
    public List<Transform> spawnPoints;

    public void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
        pointManager.score = 0;

        spawnPoints = new List<Transform>(spawnPoints);
        SpawnBerries();
    }

    public void SpawnBerries()
    {
        for ( int i = 0; i < 10000000; i++)
        {
            if (pointManager.score == 0)
            {
                var spawn = Random.Range(0, spawnPoints.Count);
                Instantiate(berries[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            }

            if (pointManager.score % 7 == 0 && pointManager.score != 0)
            {
                var spawn = Random.Range(0, spawnPoints.Count);
                Instantiate(bigBerries[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            }
        }
    }
}
