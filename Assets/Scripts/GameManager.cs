using System;
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

    public int _lifes = 3;
    public int Lifes { get { return _lifes; } }

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
        }
        else
        {
            SceneManager.LoadScene(0);  // Vuelve al Menú
        }
    }
    public void ResetLifes()
    {
        _lifes = 3;
    }

    public void EventUpdate()
    {
        _eventTimer += Time.deltaTime;
        Debug.Log(_eventTimer);
        if (_eventTimer > _eventMaxCooldown)
        {
            _eventTimer = 0;
            _eventManager.ChangeEvent();
        }

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ResetLifes();
    }

    // Update is called once per frame
    void Update()
    {
        EventUpdate();
    }

}