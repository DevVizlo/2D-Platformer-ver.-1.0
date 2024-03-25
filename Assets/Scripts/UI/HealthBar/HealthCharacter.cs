using UnityEngine;
using UnityEngine.Events;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 0.99f;
    [SerializeField] private float _health = 0.99f;
    
    public UnityAction ChangedHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Damage(float damage)
    {
        _health -= damage;
    }

    public void Heal(float heal)
    {
        _health += heal;

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }
}
