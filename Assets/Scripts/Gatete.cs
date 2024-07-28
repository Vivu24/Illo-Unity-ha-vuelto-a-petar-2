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
        if (other.gameObject.layer == 6)
        {
            Debug.Log("ostia");
            int lado = _lado[Random.Range(0, 2)];
            other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(0, 50, _force * lado);
            if (lado == 1)
            {
                GetComponent<SpriteRenderer>().sprite = _delante;
            }
            else if (lado == -1)
            {
                GetComponent<SpriteRenderer>().sprite = _detras;
            }
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == _detras || GetComponent<SpriteRenderer>().sprite == _delante)
        {
            if (_timer <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = _normal;
                _timer = 1;
            }
            _timer -= Time.deltaTime;
        }
    }

    public void FlipAndLeave()
    {
        StartCoroutine(Rotation());
        StartCoroutine(Position());
    }

    IEnumerator Rotation()
    {
        float timeToStart = Time.deltaTime;
        while (transform.rotation.y != transform.rotation.y + 180) // This is your target size of object.
        {
            //float tempTime = Mathf.Lerp(2, 0.1f, (Time.time - timeToStart) * 0.001f);//Here speed is the 1 or any number which decides the how fast it reach to one to other end.
            //transform.rotation = new Quaternion(transform.rotation.x, tempTime, transform.rotation.z, transform.rotation.w);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z, transform.rotation.w), 0.001f * timeToStart);
            timeToStart += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator Position()
    {
        _animator.Play("Walk");
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        float timeToStart = Time.deltaTime;
        while (transform.position.x != transform.position.x - 5)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), 0.001f * timeToStart);
            timeToStart += Time.deltaTime;

            yield return null;
        }
    }
}
