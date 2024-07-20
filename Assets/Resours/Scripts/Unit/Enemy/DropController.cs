using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//После смерти выбросит на пол предметы которые задали в инспекторе.
public class DropController : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public GameObject itemPrefab;
        public float dropRate;
    }
    public List<Drops> drops;
    public void Drop()
    {
        foreach (Drops rate in drops) 
        {
            float randomNumber = Random.Range(0, 100);
            if (randomNumber<=rate.dropRate) 
            {
                Instantiate(rate.itemPrefab,transform.position,Quaternion.identity);
            }
        }
    }
}
