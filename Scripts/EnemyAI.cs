using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float Speed = 4.5f;

    public UIManager uiManager;

    [SerializeField]
    private GameObject _enemyDestroyAnimation;
    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
       uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        const float horizontalBoundaryValue = 8f;
        const float verticalBoundaryValue = 7f;
        const float outOfScreenYPos = -6.5f;

        if (transform.position.y <= outOfScreenYPos)
        {
            transform.position = new Vector3(Random.Range(-horizontalBoundaryValue, horizontalBoundaryValue), verticalBoundaryValue, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_enemyDestroyAnimation, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyDestroyAnimation, transform.position, Quaternion.identity);
            uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip,Camera.main.transform.position,1f);
            Destroy(this.gameObject);
        }
    }
}
