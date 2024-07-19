using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> itemSpawnPoints;
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        spawnItems();
    }

    // Update is called once per frame
    void Update()
    {
        
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
