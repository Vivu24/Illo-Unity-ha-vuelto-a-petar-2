using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gatete : MonoBehaviour
{
    [SerializeField] private float _force;

    [SerializeField] private Sprite _normal;
    [SerializeField] private Sprite _delante;
    [SerializeField] private Sprite _detras;

    private float _timer = 1;

    private int[] _lado = {1, -1};

    private float _timeCount = 0.0f;

    private Animator _animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Debug.Log("ostia");
            int lado = _lado[Random.Range(0, 2)];
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, 50, _force * lado);
            if (lado == 1)
            {
                _animator.Play("Delante");
            }
            else if (lado == -1)
            {
                _animator.Play("Detras");
            }
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Enter()
    {
        AudioClip enfadao = GameManager.Instance.gatoEnfadao[Random.Range(0, GameManager.Instance.bostezo.Length)];

        AudioSource.PlayClipAtPoint(enfadao, new Vector3(0, 0, 0));
        StartCoroutine(GoIn());
    }

    public void FlipAndLeave()
    {
        StartCoroutine(Rotation());
        StartCoroutine(Position());
    }

    IEnumerator Rotation()
    {
        float timeToStart = Time.deltaTime;
        while (transform.rotation.y != transform.rotation.y - 180) // This is your target size of object.
        {
            //float tempTime = Mathf.Lerp(2, 0.1f, (Time.time - timeToStart) * 0.001f);//Here speed is the 1 or any number which decides the how fast it reach to one to other end.
            //transform.rotation = new Quaternion(transform.rotation.x, tempTime, transform.rotation.z, transform.rotation.w);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z, transform.rotation.w), 0.001f * timeToStart);
            timeToStart += Time.deltaTime;

            yield return null;
        }

        StopAllCoroutines();
    }

    IEnumerator Position()
    {
        _animator.SetBool("Moving", true);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        Vector3 aux = transform.position;
        float timeToStart = Time.deltaTime;
        while (transform.position.x < aux.x + 5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z), 0.001f * timeToStart);
            timeToStart += Time.deltaTime;

            yield return null;
        }
        _animator.SetBool("Moving", false);
        transform.eulerAngles = new Vector3(0, 180, 0);
        GameManager.Instance.catActive = false;
        StopAllCoroutines();
    }

    IEnumerator GoIn()
    {
        _animator.SetBool("Moving", true);
        Vector3 aux = transform.position;
        float timeToStart = Time.deltaTime;
        while (transform.position.x > aux.x - 5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z), 0.001f * timeToStart);
            timeToStart += Time.deltaTime;

            yield return null;
        }

        _animator.SetBool("Moving", false);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        StopAllCoroutines();
    }
}
