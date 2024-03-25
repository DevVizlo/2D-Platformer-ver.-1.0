using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthCharacter))]
public class Player : MonoBehaviour
{
    [Header("�������� � ����, ������")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private float _tookHealth = 0.33f;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private CoinCounter _coin;

    private HealthCharacter _healthCheracter;

    public event UnityAction DiedEvent;

    private void Awake()
    {
        _healthCheracter = GetComponent<HealthCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.TryGetComponent(out FireBallEnemy fireBall))
            {
            _healthCheracter.CheracterDamage(_tookDamage);
                Destroy(fireBall.gameObject);

                if (_healthCheracter.Health <= 0)
                    Die();

            _healthCheracter.ChangedHealth?.Invoke();
        }

        if (collision.TryGetComponent(out Heart heart))
        {
            _healthCheracter.CheracterHeal(_tookHealth);
            Destroy(heart.gameObject);

            _healthCheracter.ChangedHealth?.Invoke();
        }

        if (collision.TryGetComponent(out Coin coin))
            _coin.ReceivingCoin();

        if(collision.TryGetComponent(out PlayerDeathTrigger playerDeath))
            Die();
    }

    private void Die() => DiedEvent?.Invoke();
}