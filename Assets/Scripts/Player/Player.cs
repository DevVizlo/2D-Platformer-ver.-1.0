using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("«доровье и урон, ’илЅар")]
    [SerializeField] private float _maxHealth = 0.99f;
    [SerializeField] private float _healthPlayer = 0.99f;
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private float _tookHealth = 0.33f;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private CoinCounter _coin;

    public float Health => _healthPlayer;
    public float MaxHealth => _maxHealth;
    public event UnityAction Died;

    private void Die() => Died?.Invoke();

    private void Start()
    {
        _healthPlayer = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.TryGetComponent(out FireBallEnemy fireBall))
            {
                _healthPlayer -= _tookDamage;
                Destroy(fireBall.gameObject);

                if (_healthPlayer <= 0)
                    Die();

                _healthBar.RefreshHeart();
            }

        if (collision.TryGetComponent(out Heart heart))
        {
            _healthPlayer += _tookHealth;
            Destroy(heart.gameObject);

            if (_healthPlayer >= _maxHealth)
                _healthPlayer = _maxHealth;

            _healthBar.RefreshHeart();
        }

        if (collision.TryGetComponent(out Coin coin))
            _coin.GetCoin();

        
        if(collision.TryGetComponent(out PlayerDeathTrigger playerDeath))
            Die();
    }
}