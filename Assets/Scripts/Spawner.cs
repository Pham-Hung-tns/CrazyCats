using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float timeRespon;
    public List<Transform> position;
    void Start()
    {
        InvokeRepeating("InnitializePrefab",1,timeRespon);
    }

    private void InnitializePrefab()
    {
        Instantiate(prefab, position[Random.Range(0, position.Count - 1)].position, Quaternion.identity);
    }
}
