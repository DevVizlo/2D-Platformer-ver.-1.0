using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Здоровье и урон")]
    [SerializeField] private float _healthEnemy = 2f;
    [SerializeField] private float _tookDamage = 1f;
    [Header("Цель и снаряд")]
    [SerializeField] private Transform _receiveTargetBall;
    [SerializeField] private FireBallEnemy _ReceiveFireball;

    public Transform ReceiveFireballTarget => _receiveTargetBall;
    public FireBallEnemy ReceiveFireball => _ReceiveFireball;

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
