using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objToSpawn = new();
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.5f, spawnRate);
    }

    void Spawn()
    {
        int index = Random.Range(0, 2);
        Instantiate(objToSpawn[index], transform.position, objToSpawn[index].transform.rotation);
    }
}
