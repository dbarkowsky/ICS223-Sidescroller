using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPt;

    List<Obstacle> obstacles = new List<Obstacle>();

    private float startDelay = 2;
    private float repeatRate = 2;

    private void OnEnable()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke();
        // disable active obstacles
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                obstacles[i].enabled = false;
            }
        }
    }

    void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPt.position, obstaclePrefab.transform.rotation);
        Obstacle obstacle = obj.GetComponent<Obstacle>();
        obstacles.Add(obstacle);
    }

    public void DestroyObjects()
    {
        obstacles.ForEach(obstacle => Destroy(obstacle.gameObject));
        obstacles = new List<Obstacle>();
    }
}
