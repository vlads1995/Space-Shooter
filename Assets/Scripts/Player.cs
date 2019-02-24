using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool SpeedBoost = false;
    public bool ShieldUp = false;
    public bool isPlayerOne;
    public bool isPlayerTwo;
    // [SerializeField]
    // private GameObject 

    [SerializeField]
    private GameObject _ShieldGameObject;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _Triple_shot_laserPrefab;

    [SerializeField]
    private GameObject _Player_Explosion;

    private float _nextFire = 0.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _speed = 5.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private Spawn_Manager _spawnManager;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject[] _engines;
    private int hitCount = 0;
    public int Lives = 3;

   

    void Start()
    {
 

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLives(Lives);
        }
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();


        if (_gameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }

        /*
        if (_spawnManager != null)
        {
            _spawnManager.StartSpawn();
        }
        */
        hitCount = 0;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (isPlayerOne == true)
        {
            Movement();

#if UNITY_ANDROID
            if (Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire") && (isPlayerOne == true))
            {
                Shoot();
            }
#endif

#if UNITY_IOS
            if (Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire") && (isPlayerOne == true))
            {
                Shoot();
            }
#endif
            if (Input.GetKey(KeyCode.Space)  && (isPlayerOne == true))
            {
                Shoot();
            }

 


        }

        if (isPlayerTwo == true)
        {
            MovementTwo();

            if (Input.GetKey(KeyCode.RightShift) && (isPlayerTwo == true))
            {
                ShootTwo();
            }
        }


        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }

    

    private void Movement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        if (SpeedBoost == true)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 1.5f * verticalInput * Time.deltaTime);
        }

        if (SpeedBoost == false)
        {
            transform.Translate(Vector3.right *_speed  * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed  * verticalInput * Time.deltaTime);
        }

        if (SpeedBoost == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right *  _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left *  _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down *  _speed * Time.deltaTime);
            }
        }
        if (SpeedBoost == true)
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * 1.5f * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * 1.5f * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * 1.5f * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * 1.5f * _speed * Time.deltaTime);
            }
        }
        // bounds y position
        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, transform.position.z);
        }
        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        }

        //warp x position
        if (transform.position.x > 10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }
    }

    private void MovementTwo()
    {
      
         
        if (SpeedBoost == false)
        {
            if (Input.GetKey(KeyCode.O))
            {
                transform.Translate(Vector3.up * 1.5f *_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Semicolon))
            {
                transform.Translate(Vector3.right * 1.5f * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(Vector3.left * 1.5f * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(Vector3.down * 1.5f * _speed * Time.deltaTime);
            }
        }
        if (SpeedBoost == true)
        {
            if (Input.GetKey(KeyCode.O))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Semicolon))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
        }
   
    
    // bounds y position
        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, transform.position.z);
        }
        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        }

        //warp x position
        if (transform.position.x > 10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }
    }


    private void Shoot()
    {
        
        if (Time.time >= _nextFire)
        {
           
            if (canTripleShot == false)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                _nextFire = Time.time + _fireRate;
                _audioSource.Play();
                
            }
            if (canTripleShot == true)
            {  
                Instantiate(_Triple_shot_laserPrefab, transform.position, Quaternion.identity);
                _nextFire = Time.time + _fireRate;
                _audioSource.Play();
            }
        }
    }
    private void ShootTwo()
    {

        if (Time.time >= _nextFire)
        {

            if (canTripleShot == false)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                _nextFire = Time.time + _fireRate;
                _audioSource.Play();

            }
            if (canTripleShot == true)
            {
                Instantiate(_Triple_shot_laserPrefab, transform.position, Quaternion.identity);
                _nextFire = Time.time + _fireRate;
                _audioSource.Play();
            }
        }
    }


    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }

    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void SpeedPowerUpOn()
    {
        SpeedBoost = true;
        StartCoroutine(SpeedPowerDown());
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        SpeedBoost = false;
    }

    public void Damage()
    {
      
        

        if (ShieldUp == false)
        {
            Lives--;
            hitCount++;
            _uiManager.UpdateLives(Lives);
        }

        if (hitCount == 1)
        {
           
            _engines[UnityEngine.Random.RandomRange(0, 2)].SetActive(true);
        }
        if (hitCount == 2)
        {
            _engines[0].SetActive(true);
            _engines[1].SetActive(true);
        }

        else if (ShieldUp == true)
        {
            ShieldUp = false;
            _ShieldGameObject.SetActive(false);
            //return;
        }

        if (Lives <1)
        {
            Destroy(this.gameObject);
            Instantiate(_Player_Explosion, transform.position, Quaternion.identity);
           
            _gameManager.gameOver = true;
            _uiManager.ShowTitle();


        }
    }

    public void ShieldPowerUpOn()
    {
        ShieldUp = true;

        _ShieldGameObject.SetActive(true);
 

    }

}