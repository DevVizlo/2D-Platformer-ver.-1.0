using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private const string _animRun = "Run";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove = 0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        bool isMove = Input.GetKey(KeyCode.D);
        _animator.SetBool(_animRun, isMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove * 10f, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = targetVelocity;
    }
}
