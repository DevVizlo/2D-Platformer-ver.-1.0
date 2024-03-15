using UnityEngine;
using UnityEngine.Events;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] protected float _maxHealth = 0.99f;
    [SerializeField] protected float _health = 0.99f;
    
    public UnityAction ChangingHealth;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
}
