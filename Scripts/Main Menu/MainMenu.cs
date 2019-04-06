using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadSingplePlayerGame()
    {
      SceneManager.LoadScene("Single_player");
    }

    public void LoadCoOpGame()
    {
        SceneManager.LoadScene("Co_op_mode");
    }
}
