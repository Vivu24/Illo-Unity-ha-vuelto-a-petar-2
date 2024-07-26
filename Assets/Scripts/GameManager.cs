using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region REFERENCES

    //Singleton of game manager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

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
            // Finalizar Juego
        }
    }
    public void ResetLifes()
    {
        _lifes = 3;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}