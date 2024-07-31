using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region REFERENCES

    //Singleton of game manager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    private EventManager _eventManager;
    public Transform _rbSpawner;
    public GameObject _rbSpawnerPrefab;

    public GameObject[] vidas;

    #endregion

    #region PROPERTIES

    // CAN CADENCY //
    [SerializeField]
    private float _canCadency;
    public float CanCadency { get { return _canCadency; } }

    // LOADING BELT //
    [SerializeField]
    private float _loadingBeltVelocity;
    public float LoadingBeltVelocity { get { return _loadingBeltVelocity; } }

    // EVENT TIMER //
    [SerializeField]
    private float _eventMaxCooldown;
    [SerializeField]
    private float _eventTimer = 0;
    [SerializeField]
    private float _eventLimitCooldown = 1;

    // CAN CADENCY TIMER //
    [SerializeField]
    private float _canMaxCooldown;
    [SerializeField]
    private float _canTimer = 0;
    [SerializeField]
    private float _canLimitVelocity = 1;

    // LOADING BELT TIMER //
    [SerializeField]
    private float _beltMaxCooldown;
    [SerializeField]
    private float _beltTimer = 0;


    [SerializeField]
    private int _totalEventCounter = 0;
    [SerializeField]
    private int _maxNumberOfEvents;

    public int _lifes = 3;
    public int Lifes { get { return _lifes; } }


    private int _score = 0;
    public int Score { get { return _score; } }

    // FLY COUNTER //
    [SerializeField]
    public int _flies = 0;
    public float timePlayed = 5f;
    public float canAcuraccy;
    public float cansDeployed = 5f;
    public float cansEnBasura;
    public int Flies { get { return _flies; } }
    public int getFlies()
    {
        return _flies;
    }
    public float getTime()
    {
        Debug.Log("Mitiempo es: " + timePlayed);
        return timePlayed;
    }

    public bool catActive = false;
    public bool boss1Active = false;
    public bool boss2Active = false;
    public bool boss3Active = false;


    [SerializeField]
    public AudioClip[] bostezo;
    public AudioClip[] fallo;
    public AudioClip[] gatoFeliz;
    public AudioClip[] gatoEnfadao;
    private float startTime;
    #endregion


    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
        startTime = Time.time;
        DontDestroyOnLoad(this);
    }


    #region METHODS
    
    public void LoseLife()
    {
        Camera.main.GetComponent<Shake>().start = true;
        if (_lifes > 1)
        {
            SonidoFallo();
            _lifes--;
            vidas[_lifes].gameObject.SetActive(false);
        }
        else
        {
            SonidoFallo();
            PlayerDies();
        }
    }
    public void PlayerDies()
    {
        SceneManager.LoadScene("QuechuScene");
    }
    public void ResetLifes()
    {
        _lifes = 3;
    }

    public void EventUpdate()
    {
        if(_lifes > 0)
        {
            _eventTimer += Time.deltaTime;
            if (_eventTimer > _eventMaxCooldown)
            {
                CalculateEventTimer();
                _eventTimer = 0;
                if(SceneManager.GetActiveScene().name == "MainPrueba")
                { 
                    _eventManager.ChangeEvent(UnityEngine.Random.Range(1, _maxNumberOfEvents + 1)); 
                }
                _totalEventCounter++;
            }
        }
        

    }

    public void SonidoFallo()
    {
        AudioSource.PlayClipAtPoint(fallo[0], new Vector3(0, 0, 0));
    }
    public void CalculateEventTimer()
    {
        if (_eventMaxCooldown > _eventLimitCooldown)
        {
            _eventMaxCooldown -= 0.15f;
        }
    }
    public void CanUpdate()
    {
        _canTimer += Time.deltaTime;
        if (_canTimer > _canMaxCooldown)
        {
            CalculateCanTimer();
            _canTimer = 0;
            
        }
    }
    public void CalculateCanTimer()
    {
        if (_canCadency > _canLimitVelocity)
        {
            _canCadency -= 0.25f;
        }
    }
    public void LoadingBeltUpdate()
    {
        _beltTimer += Time.deltaTime;
        if (_beltTimer > _beltMaxCooldown)
        {
            CalculateEventTimer();
            _beltTimer = 0;
            _loadingBeltVelocity += 0.15f;
        }
    }

    public void AddPoints(int n)
    {
        _score += n;
        Debug.Log("Current Score: " + _score);
    }

    public void AddFlies(int n)
    {
        _flies += n;
    }

    public void ResetFlies()
    {
        _flies = 0;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void drinkRedbull()
    {
        _eventManager.GetComponent<TiredEvent>().restartCaffeine();
    }

    public void spawnRedbull()
    {
        Instantiate(_rbSpawnerPrefab, _rbSpawner.position, Quaternion.identity);
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ResetLifes();
        ResetScore();
        ResetFlies();
    }

    // Update is called once per frame
    void Update()
    {
        EventUpdate();
        LoadingBeltUpdate();
        CanUpdate();

        timePlayed = Time.time - startTime;
        if (cansDeployed >= 5 && SceneManager.GetActiveScene().name == "MainPrueba")
        {
            canAcuraccy = cansEnBasura / cansDeployed;
            if (canAcuraccy < 0.3f)
                {
                    PlayerDies();
                Debug.Log("cANaCURAZY: "+ canAcuraccy);
                }
        }
       
    }

}