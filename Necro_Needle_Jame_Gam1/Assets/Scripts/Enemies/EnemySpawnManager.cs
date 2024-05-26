using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private int difficultyTimer = 20;
    private int spawnTimer = 10;
    private int numberOfSpawns = 1;
    private bool canSpawn = false;


    private void Start()
    {
        StartCoroutine(AskForSpawn());
        StartCoroutine(SetDifficulty());
    }


    private void UpDifficulty()
    {
        numberOfSpawns++;
    }



    private IEnumerator SetDifficulty()
    {
        yield return new WaitForSeconds(difficultyTimer);
        UpDifficulty();
        StartCoroutine(SetDifficulty());
    }

    private IEnumerator AskForSpawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
        StartCoroutine(AskForSpawn());
    }

    public int GetCurrentDifficulty()
    {
        return numberOfSpawns;
    }

    public bool CanSpawn()
    {
        return canSpawn;
    }
    public void ResetSpawnBool()
    {
        canSpawn = false;
    }
}
