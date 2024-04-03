using System.Collections;
using UnityEngine;

public class Vampirizm : MonoBehaviour
{
    [SerializeField] private HealthCharacter _healthPlayer;
    [SerializeField] private float _spellDuration;

    private float _actionTime = 6f;
    private float _recharge = 8f;
    private float _nextActionTime = 0f;
    private float _damageDealRate = 0.3f;
    private float _cooldown = 10f;

    private WaitForSeconds _waitCooldown;
    private WaitForSeconds _damageRate;

    private Coroutine _vampirismCast;
    private Enemy _enemy;
    private float _damagePerSecond = 0.05f;
    private bool _isEnemyDetected;

    private void Awake()
    {
        _waitCooldown = new WaitForSeconds(_cooldown);
        _damageRate = new WaitForSeconds(_damageDealRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _isEnemyDetected = true;
            _enemy = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy _))
        {
            _isEnemyDetected = false;
        }
    }

    public void ActivateSpell()
    {
        if (_isEnemyDetected == true)
        {
            if (Time.time >= _nextActionTime)
            {
                _vampirismCast = StartCoroutine(ActivateVampirism(_enemy));
            }
        }
        else if (_vampirismCast != null)
        {
            StopCoroutine(_vampirismCast);
        }
    }

    private IEnumerator ActivateVampirism(Enemy enemy)
    {
        _nextActionTime = Time.time + _recharge;

        for (int i = 0; i < _actionTime; i++)
        {
                _healthPlayer.Heal(_damagePerSecond);
                enemy.ReceivedDamage(_damagePerSecond);

                yield return _damageRate;
        }

        yield return _waitCooldown;
    }
}