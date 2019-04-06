using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    private Animator _anim;
    private Player player;
    void Start()
    {
        _anim = GetComponent<Animator>();
        player =  GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isPlayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", true);
            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }
        }

        if (player.isPlayerTwo == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _anim.SetBool("Turn_Left", true);
                _anim.SetBool("Turn_Right", false);
            }

            else if (Input.GetKeyUp(KeyCode.K))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", true);
            }

            else if (Input.GetKeyUp(KeyCode.Semicolon))
            {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", false);
            }
        }
    }
}
