using UnityEngine;

public class Powerup : MonoBehaviour
{
    private const float Speed = 3.0f;

    [SerializeField]
    private int powerupID; // 0- triple, 1- speed, 2- shield
    [SerializeField]
    private AudioClip _clip;

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime );
        if (transform.position.y <= - 6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotPowerUpOn();
                        break;
                    case 1:
                        player.SpeedPowerUpOn();
                        break;
                    case 2:
                        player.ShieldPowerUpOn();
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
