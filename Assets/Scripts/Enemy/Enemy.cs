using UnityEngine;

[RequireComponent(typeof(HealthCharacter))]
public class Enemy : MonoBehaviour
{
    [Header("�������� � ����")]
    [SerializeField] private float _tookDamage = 0.33f;
    [SerializeField] private HealthBar _healthBar;

    [Header("���� � ������")]
    [SerializeField] private Transform _receiveTargetBall;
    [SerializeField] private FireBallEnemy _ReceiveFireball;


    public Transform ReceiveFireballTarget => _receiveTargetBall;
    public FireBallEnemy ReceiveFireball => _ReceiveFireball;

    private HealthCharacter _healthCheracter;

    private void Awake()
    {
        _healthCheracter = GetComponent<HealthCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBallPlayer fireBall))
        {
            _healthCheracter.CheracterDamage(_tookDamage);
            Destroy(fireBall.gameObject);
            _healthCheracter.ChangedHealth?.Invoke();

            if (_healthCheracter.Health <= 0)
                Die();
        }
    }

    private void Die() => Destroy(gameObject);
}
