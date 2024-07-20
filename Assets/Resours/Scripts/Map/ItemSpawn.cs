using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> itemSpawnPoints;
    public List<GameObject> items;

    void Start()
    {
        spawnItems();
    }
    void spawnItems()
    {
        foreach (GameObject spawnPoint in itemSpawnPoints)
        {
            int randItem = Random.Range(0, items.Count);
            Instantiate(items[randItem], spawnPoint.transform.position, Quaternion.identity, this.gameObject.transform);
        }

    }
}
