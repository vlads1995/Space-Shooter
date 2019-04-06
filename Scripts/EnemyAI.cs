using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{ 
    [SerializeField]
    private GameObject _EnemyDestroyAnimation;
    private float _speed = 4.5f;
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip _clip;
  
    public UIManager _uiManager;   
   
    void Start()
    {

       _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
                
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.5f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0);

        }
  
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
           
           
            Instantiate(_EnemyDestroyAnimation, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
          
            
            Instantiate(_EnemyDestroyAnimation, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip,Camera.main.transform.position,1f);
            
            Destroy(this.gameObject);
        }
    }

     

}
