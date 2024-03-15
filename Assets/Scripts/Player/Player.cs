using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(HealthCharacter))]
public class Player : HealthCharacter
{
    [Header("«доровье и урон, ’илЅар")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private float _tookHealth = 0.33f;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private CoinCounter _coin;

    public event UnityAction DiedEvent;

    private void Die() => DiedEvent?.Invoke();

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.TryGetComponent(out FireBallEnemy fireBall))
            {
                _health -= _tookDamage;
                Destroy(fireBall.gameObject);

                if (_health <= 0)
                    Die();

            ChangingHealth?.Invoke();
        }

        if (collision.TryGetComponent(out Heart heart))
        {
            _health += _tookHealth;
            Destroy(heart.gameObject);

            if (_health >= _maxHealth)
                _health = _maxHealth;

            ChangingHealth?.Invoke();
        }

        if (collision.TryGetComponent(out Coin coin))
            _coin.ReceivingCoin();

        if(collision.TryGetComponent(out PlayerDeathTrigger playerDeath))
            Die();
    }
}