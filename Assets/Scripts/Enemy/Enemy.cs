using UnityEngine;

[RequireComponent(typeof(HealthCharacter))]
public class Enemy : HealthCharacter
{
    [Header("Здоровье и урон")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private HealthBar _healthBar;

    [Header("Цель и снаряд")]
    [SerializeField] private Transform _receiveTargetBall;
    [SerializeField] private FireBallEnemy _ReceiveFireball;


    public Transform ReceiveFireballTarget => _receiveTargetBall;
    public FireBallEnemy ReceiveFireball => _ReceiveFireball;

    private void Die() => Destroy(gameObject);

    private void Start()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBallPlayer fireBall))
        {
            _health -= _tookDamage;
            Destroy(fireBall.gameObject);
            ChangingHealth?.Invoke();

            if (_health <= 0)
                Die();
        }
    }
}
