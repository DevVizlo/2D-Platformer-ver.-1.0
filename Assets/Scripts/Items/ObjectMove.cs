using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMove : MonoBehaviour
{
    [Header("Звук, время удаления, скорость")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timeDestroy = 5f;
    [SerializeField] private float _speed = 2;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _audioSource.Play();

            _rigidbody2D.velocity = transform.up * _speed;
            Invoke("DestrroyCoin", _timeDestroy);
        }
    }

    private void DestrroyCoin()
    {
        gameObject.SetActive(false);
    }
}
