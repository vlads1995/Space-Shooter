using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadSingplePlayerGame()
    {
        //Debug.Log("Single Player Game Loading...");

      SceneManager.LoadScene("Single_player");

    }

    public void LoadCoOpGame()
    {
        //Debug.Log("Single Player Game Loading...");

        SceneManager.LoadScene("Co_op_mode");

    }

}
