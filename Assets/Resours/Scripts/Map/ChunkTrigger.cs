using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public GameObject targetMap;
    void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MapController.currentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (MapController.currentChunk == targetMap)
            {
                MapController.currentChunk = null;
            }
        }
    }
}
