using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireBallPlayer : MonoBehaviour
{
    [Header("Время действия, скорость, направление")]
    [SerializeField] private float _timeDestroy = 6f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _offset = 1f;

    private AudioSource _fireBallSound;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

        _rigidbody2D.velocity = transform.up * _speed;
        Invoke(nameof(DestrroyFireBall), _timeDestroy);
    }

        private void DestrroyFireBall()
        {
            Destroy(this.gameObject);
        }
    }
