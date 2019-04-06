using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;
    private GameManager _gameManager;

    

    public bool gameOver;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());

        StartCoroutine(PowerupSpawn());
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemy());

        StartCoroutine(PowerupSpawn());
    }


 
    public IEnumerator SpawnEnemy()
    {
        while (_gameManager.gameOver ==false)
        {
           
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }
    }
      
    public IEnumerator PowerupSpawn()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }

    }



}
