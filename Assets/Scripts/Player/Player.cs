using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthCharacter))]
public class Player : MonoBehaviour
{
    [Header("«доровье и урон, ’илЅар")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private float _tookHealth = 0.33f;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private CoinCounter _coin;
    [SerializeField] private Vampirizm _spell;


    private HealthCharacter _healthCheracter;
    private float _hpDeath = 0.32f;

    public event UnityAction DiedEvent;

    private void Awake()
    {
        _healthCheracter = GetComponent<HealthCharacter>();
    }

    private void Update()
    {
        bool _isVampirizmActivation = Input.GetKeyDown(KeyCode.R);
        if (_isVampirizmActivation)
            _spell.ActivateSpell();
    }

    public void TriggerCharacter(Collider2D collision)
    {
            if (collision.TryGetComponent(out FireBallEnemy fireBall))
            {
            _healthCheracter.Damage(_tookDamage);
                Destroy(fireBall.gameObject);

                if (_healthCheracter.Health <= _hpDeath)
                    Die();

            _healthCheracter.ChangedHealth?.Invoke();
            }

        if (collision.TryGetComponent(out Heart heart))
        {
            _healthCheracter.Heal(_tookHealth);
            Destroy(heart.gameObject);

            _healthCheracter.ChangedHealth?.Invoke();
        }

        if (collision.TryGetComponent(out Coin coin))
            _coin.ReceivCoin();

        if(collision.TryGetComponent(out PlayerDeathTrigger playerDeath))
            Die();
    }

    private void Die() => DiedEvent?.Invoke();
}