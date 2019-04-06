using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private const float _fireRate = 0.25f;
    private const float _speed = 5.0f;

    public bool canTripleShot = false;
    public bool speedBoost = false;
    public bool shieldUp = false;
    public bool isPlayerOne;
    public bool isPlayerTwo;
    public int lives = 3;

    private float _nextFire = 0.0f;
    private UIManager _uiManager;
    private GameManager _gameManager;
    private Spawn_Manager _spawnManager;
    private AudioSource _audioSource;
    private int _hitCount = 0;

    [SerializeField]
    private GameObject _ShieldGameObject;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _Triple_shot_laserPrefab;
    [SerializeField]
    private GameObject _Player_Explosion;
    [SerializeField]
    private GameObject[] _engines;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
        }
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();

        if (_gameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        _hitCount = 0;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (isPlayerOne == true)
        {
            Movement();
            if (Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire") && (isPlayerOne == true))
            {
                Shoot();
            }
        }

        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void Movement()
    {
        var horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        var verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        const float speedBoostCorrector = 1.5f;

        if (speedBoost == true)
        {
            transform.Translate(Vector3.right * _speed * speedBoostCorrector * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * speedBoostCorrector * verticalInput * Time.deltaTime);
        }

        if (speedBoost == false)
        {
            transform.Translate(Vector3.right *_speed  * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed  * verticalInput * Time.deltaTime);
        }

        //Bounds y position
        const float boundYPos = 4.2f;
        if (transform.position.y > boundYPos)
        {
            transform.position = new Vector3(transform.position.x, boundYPos, transform.position.z);
        }
        if (transform.position.y < -boundYPos)
        {
            transform.position = new Vector3(transform.position.x, -boundYPos, transform.position.z);
        }

        //Warp x position
        const float boundXPos = 10f;
        if (transform.position.x > boundXPos)
        {
            transform.position = new Vector3(-boundXPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -boundXPos)
        {
            transform.position = new Vector3(boundXPos, transform.position.y, transform.position.z);
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
        speedBoost = true;
        StartCoroutine(SpeedPowerDown());
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoost = false;
    }

    public void Damage()
    {
        if (shieldUp == false)
        {
            lives--;
            _hitCount++;
            _uiManager.UpdateLives(lives);
        }

        if (_hitCount == 1)
        {           
            _engines[Random.RandomRange(0, 2)].SetActive(true);
        }
        if (_hitCount == 2)
        {
            _engines[0].SetActive(true);
            _engines[1].SetActive(true);
        }

        else if (shieldUp == true)
        {
            shieldUp = false;
            _ShieldGameObject.SetActive(false);
        }

        if (lives <1)
        {
            Destroy(this.gameObject);
            Instantiate(_Player_Explosion, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uiManager.ShowTitle();
        }
    }

    public void ShieldPowerUpOn()
    {
        shieldUp = true;
        _ShieldGameObject.SetActive(true);
    }
}