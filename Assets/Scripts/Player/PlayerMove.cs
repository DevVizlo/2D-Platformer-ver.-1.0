using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private const string _animRun = "Run";
    private const string _direction = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private float _powerMovement = 10f;
    private float _horizontalMove = 0f;
    private bool _isJump;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(_direction) * _speed;

        bool isMove = Input.GetKey(KeyCode.D);
        _animator.SetBool(_animRun, isMove);
        _isJump = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        Vector2 targetVelocity = new Vector2(_horizontalMove * _powerMovement, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = targetVelocity;
    }
}
