using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; // 0- triple, 1- speed, 2- shield

    [SerializeField]
    private AudioClip _clip;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime );
        if (transform.position.y <= - 6f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player")
       {
          
           Player player = other.GetComponent<Player>();
           AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
           {
                
                if (powerupID == 0)
                {
                    player.TripleShotPowerUpOn();
                }

                if (powerupID == 1)
                {
                    player.SpeedPowerUpOn();
                }

                if (powerupID == 2)
                {
                    player.ShieldPowerUpOn();
                }
                

            }

          
           Destroy(this.gameObject);

       }

    }

   
}
