using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noterrainPosition;
    public LayerMask terrainMask;
    PlayerController pm;
    [SerializeField] GameObject spawnerObj;
    EnemySpawnManager spawnManager;
    [SerializeField] float chunkSize;
    public GameObject currentChunk;
    private int availableSpawns;

    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        pm = FindObjectOfType<PlayerController>();
        spawnManager = spawnerObj.GetComponent<EnemySpawnManager>();
    }

    private void Update()
    {
        ChunkChecker();
        AskforSpawn();
        SetDifficulty();
    }

    private void AskforSpawn()
    {
        if (!currentChunk)
        {
            return;
        }

        if (availableSpawns > 0)
        {
            GameObject enemy;
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Right").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Left").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Top").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Bottom").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Right Up").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Left Up").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Left Bottom").transform);
            enemy.SetActive(true);
            enemy = Instantiate(enemyPrefab, currentChunk.transform.Find("Right Bottom").transform);
            enemy.SetActive(true);
            availableSpawns--;
        }
    }

    private void SetDifficulty()
    {
        if (!currentChunk)
        {
            return;
        }

        if (spawnManager.CanSpawn())
        {
            availableSpawns = spawnManager.GetCurrentDifficulty();
            spawnManager.ResetSpawnBool();
        }
    }


    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        //---------------------------------------------------------------------------------------------------------------------
        if (pm.movement.y > 0 && pm.movement.x > 0) //up right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        else if (pm.movement.y > 0 && pm.movement.x < 0) //up left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        else if (pm.movement.y < 0 && pm.movement.x > 0) //down right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Bottom").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Right Bottom").position;
                SpawnChunk();
            }
        }
        else if (pm.movement.y < 0 && pm.movement.x < 0) //down left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Bottom").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Left Bottom").position;
                SpawnChunk();
            }
        }
//-------------------------------------------------------------------------------------------------------------------------
        if (pm.movement.x > 0 && (pm.movement.y > 0.1f || pm.movement.y < -0.1f)) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }

        else if (pm.movement.x < 0 && (pm.movement.y > 0.1f || pm.movement.y < -0.1f)) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
//------------------------------------------------------------------------------------------------------------------------
        if (pm.movement.y > 0 && (pm.movement.x > 0.1f || pm.movement.x < -0.1f)) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Top").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Top").position;
                SpawnChunk();
            }
        }
        else if (pm.movement.y < 0 && (pm.movement.x > 0.1f || pm.movement.x < -0.1f)) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Bottom").position, checkerRadius, terrainMask))
            {
                noterrainPosition = currentChunk.transform.Find("Bottom").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noterrainPosition, Quaternion.identity);
    }
}