using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public GameObject pauseMenu;
    public bool gameOver = true;
    public GameObject player;
    public GameObject coopPlayers;
    public bool isCoopMode = false;

    private Spawn_Manager _spawnManager;
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)   && (gameOver == false))
        {
            pauseMenu.SetActive(true);
 
            if (pauseMenu.activeInHierarchy == true)
            {
                PauseGame();
            }
            if (pauseMenu.activeInHierarchy == false)
            {
                ResumeGame();
            }
        }
 
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R)  )            
            {
                if (isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                if (isCoopMode == true)
                {
                   
                    Instantiate(coopPlayers, Vector3.zero, Quaternion.identity);
                }
                gameOver = false;
                _uiManager.HideTitle();
                _spawnManager.StartSpawn();
            }
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
