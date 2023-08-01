using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objToSpawn = new();
    [SerializeField]
    private float spawnRate;
    public float SpawnRate
    {
        get { return spawnRate; } 
        set { if (value > 0) 
                {
                    spawnRate = value;
                }  
            }
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.5f, spawnRate);
    }

    private void Spawn()
    {
        int index = Random.Range(0, 2);
        Instantiate(objToSpawn[index], transform.position, objToSpawn[index].transform.rotation);
    }
}
