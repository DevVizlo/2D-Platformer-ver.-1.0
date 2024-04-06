using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Vampirizm : MonoBehaviour
{
    private const string VampirizmAnim = "Vampirizm";

    [SerializeField] private HealthCharacter _healthPlayer;
    [SerializeField] private float _spellDuration;
    [SerializeField] private LayerMask _enemiesLayer;
    [SerializeField] private VampirizmAnimation _radiusVampirism;
    [SerializeField] private float _range = 3f;

    private float _actionTime = 6f;
    private float _recharge = 8f;
    private float _nextActionTime = 0f;
    private float _damageDealRate = 0.6f;

    private WaitForSeconds _damageRate;
    private Coroutine _vampirismCast;
    private float _damagePerSecond = 0.03f;
    private Collider2D[] _colliders;

    private Animator _playerVampirism;

    private void Awake()
    {
        _damageRate = new WaitForSeconds(_damageDealRate);
        _playerVampirism = GetComponent<Animator>();
    }

    public void ActivateSpell()
    {
            if (Time.time >= _nextActionTime)
            {
            _vampirismCast = StartCoroutine(ActivateVampirism());
            _radiusVampirism.StartAnimationRadius();
            _playerVampirism.SetTrigger(VampirizmAnim);
            }
            else if(_vampirismCast != null)
            {
            StopCoroutine(_vampirismCast);
            }
    }

    private IEnumerator ActivateVampirism()
    {
        _nextActionTime = Time.time + _recharge;
        _colliders = Physics2D.OverlapCircleAll(transform.position, _range, _enemiesLayer);

        foreach (Collider2D collider in _colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                if (_colliders.Length != 0)
                {
                    for (int j = 0; j < _colliders.Length; j++)
                    {
                        for (int i = 0; i < _actionTime; i++)
                        {
                            _healthPlayer.Heal(_damagePerSecond);
                            enemy.ReceivedDamage(_damagePerSecond);

                            yield return _damageRate;
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}