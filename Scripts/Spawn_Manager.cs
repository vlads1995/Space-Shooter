using System.Collections;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public bool gameOver;

    [SerializeField]
    private GameObject _enemyShipPrefab;
    [SerializeField]
    private GameObject[] _powerups;
    private GameManager _gameManager;

    private void Start()
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
            Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
      
    public IEnumerator PowerupSpawn()
    {
        while (_gameManager.gameOver == false)
        {
            var randomPowerup = Random.Range(0, 3);
            Instantiate(_powerups[randomPowerup], new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
