using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float chekerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerControler playerControler;
    public static GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> terrainChunksList;
    GameObject latestChunk;
    public float maxEnableDist;
    float opDist;
    // Start is called before the first frame update
    void Start()
    {
        playerControler = FindObjectOfType<PlayerControler>();
        StartCoroutine(chunkOptimizer());
    }

    // Update is called once per frame
    void Update()
    {
         ChunkCheker();
    }
    private void ChunkCheker()
    {
        if (!currentChunk)
        {
            return;
        }
        if (playerControler.playerInput.x > 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(50, 0, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(50, 0, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(50, 50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(50, 50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(50, -50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(50, -50, 0);
                SpawnChunk();
            }
        }
        else if(playerControler.playerInput.x < 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(-50, 0, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(-50, 0, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(-50, 50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(-50, 50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(-50, -50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(-50, -50, 0);
                SpawnChunk();
            }
        }
        if (playerControler.playerInput.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(0, 50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(0, 50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(50, 50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(50, 50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(-50, 50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(-50, 50, 0);
                SpawnChunk();
            }
        }
        else if (playerControler.playerInput.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(0, -50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(0, -50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(50, -50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(50, -50, 0);
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.position + new Vector3(-50, -50, 0), chekerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.position + new Vector3(-50, -50, 0);
                SpawnChunk();
            }
        }

    }
    void SpawnChunk()
    {
        int rand = Random.Range(0,terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity, gameObject.transform);
        terrainChunksList.Add(latestChunk);
    }
    IEnumerator chunkOptimizer()
    {
        for (; ; )
        {
            foreach (GameObject chunk in terrainChunksList)
            {
                opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
                if (opDist > maxEnableDist)
                {
                    chunk.SetActive(false);
                }
                else
                {
                    chunk.SetActive(true);
                }

            }
            yield return new WaitForSeconds(5);
        }

    }
}
