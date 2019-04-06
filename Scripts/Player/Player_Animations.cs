using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    private Animator _anim;
    private Player _player;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _player =  GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.isPlayerOne == true)
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

        if (_player.isPlayerTwo == true)
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
