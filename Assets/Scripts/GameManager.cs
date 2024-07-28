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
    private int _flies;
    public int Flies { get { return _flies; } }

    public bool catActive = false;
    public bool bossActive = false;

    [SerializeField]
    public AudioClip[] bostezo;
    public AudioClip[] fallo;
    public AudioClip[] gatoFeliz;
    public AudioClip[] gatoEnfadao;

    #endregion


    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }


    #region METHODS
    
    public void LoseLife()
    {
        if (_lifes > 1)
        {
            
            _lifes--;
            vidas[_lifes].gameObject.SetActive(false);
        }
        else
        {
            
            PlayerDies();
        }
    }
    public void PlayerDies()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }
    public void ResetLifes()
    {
        _lifes = 3;
    }

    public void EventUpdate()
    {
        _eventTimer += Time.deltaTime;
        if (_eventTimer > _eventMaxCooldown)
        {
            CalculateEventTimer();
            _eventTimer = 0;
            _eventManager.ChangeEvent(UnityEngine.Random.Range(1, _maxNumberOfEvents + 1));
            _totalEventCounter++;
        }

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
        _flies = 12;
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
    }

}