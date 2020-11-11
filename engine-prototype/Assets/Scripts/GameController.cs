using Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 playerSpawn = new Vector3(0.5f,0.5f,0.5f);
    private BasicPlayer player;
    public GameObject enemyPrefab;
    private BasicMeleeEnemy enemy;
    public Vector3 enemySpawn = new Vector3(4f, 0.5f, 4f);
    public int playerLevel = 1; //TODO load player level somehow

    void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
        //TODO Load player details
        //TODO Construct dungeon
        //TODO Load enemy prefabs
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        GameObject playerInstance = Instantiate(playerPrefab, playerSpawn, Quaternion.identity) as GameObject;
        player = playerInstance.GetComponent<BasicPlayer>();
        player.Initialise(playerLevel);
    }

    public void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, enemySpawn, Quaternion.identity) as GameObject;
        enemy = enemyInstance.GetComponent<BasicMeleeEnemy>();
        enemy.Initialise(1);
    }
}
