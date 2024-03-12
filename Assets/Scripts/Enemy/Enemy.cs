using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Здоровье и урон")]
    [SerializeField] private float _maxHealth = 0.99f;
    [SerializeField] private float _healthEnemy = 0.99f;
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private EnemyHealthBar _healthBar;
    [Header("Цель и снаряд")]
    [SerializeField] private Transform _receiveTargetBall;
    [SerializeField] private FireBallEnemy _ReceiveFireball;


    public float Health => _healthEnemy;
    public float MaxHealth => _maxHealth;

    public Transform ReceiveFireballTarget => _receiveTargetBall;
    public FireBallEnemy ReceiveFireball => _ReceiveFireball;

    private void Die() => Destroy(gameObject);

    private void Start()
    {
        _healthEnemy = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBallPlayer fireBall))
        {
            _healthEnemy -= _tookDamage;
            _healthBar.RefreshHeart();
            Destroy(fireBall.gameObject);

            if (_healthEnemy <= 0)
                Die();
        }
    }
}
