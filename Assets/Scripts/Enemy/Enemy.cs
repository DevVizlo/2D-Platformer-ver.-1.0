using UnityEngine;

[RequireComponent(typeof(HealthCharacter))]
public class Enemy : MonoBehaviour
{
    [Header("Здоровье и урон")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private HealthBar _healthBar;

    [Header("Цель и снаряд")]
    [SerializeField] private Transform _receiveTargetBall;
    [SerializeField] private FireBallEnemy _ReceiveFireball;


    public Transform ReceiveFireballTarget => _receiveTargetBall;
    public FireBallEnemy ReceiveFireball => _ReceiveFireball;

    private HealthCharacter _healthCheracter;
    private float _hpDeath = 0.32f;

    private void Awake()
    {
        _healthCheracter = GetComponent<HealthCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBallPlayer fireBall))
        {
            Destroy(fireBall.gameObject);
            ReceivedDamage(_tookDamage);
        }
    }

    public void ReceivedDamage(float resultDamage)
    {
        _healthCheracter.Damage(resultDamage);
        if (_healthCheracter.Health <= _hpDeath)
            Die();

        _healthCheracter.ChangedHealth?.Invoke();
    }

    private void Die() => Destroy(gameObject);
}
