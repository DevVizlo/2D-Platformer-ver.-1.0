using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string _animRun = "Run";
    private const string _direction = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private float _powerMovement = 10f;
    private float _horizontalMove = 0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove * _powerMovement, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = targetVelocity;
    }

    public void MoveHorizontal(bool isMove)
    {
        _horizontalMove = Input.GetAxisRaw(_direction) * _speed;
        _animator.SetBool(_animRun, isMove);
    }

    public void PlayerJump(bool _isJump)
    {
        if (_isJump)
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}
