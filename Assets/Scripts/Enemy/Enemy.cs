using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Здоровье и урон")]
    [SerializeField] private float _healthEnemy = 2f;
    [SerializeField] private float _tookDamage = 1f;
    [Header("Цель и снаряд")]
    [SerializeField] private Transform _targetBall;
    [SerializeField] private FireBallEnemy _Fireball;

    public Transform ReceiveBallTarget { get { return _targetBall; } }
    public FireBallEnemy ReceiveBall { get { return _Fireball; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBallPlayer fireBall))
        {
            _healthEnemy -= _tookDamage;
            if (_healthEnemy <= 0)
                Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
