using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Здоровье и урон")]
        [SerializeField] private float _maxHealth = 3f;
        [SerializeField] private float _healthPlayer = 3f;
        [SerializeField] private float _tookDamage = 1f;
        [SerializeField] private float _tookHealth = 1f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FireBallEnemy fireBall))
            {
                _healthPlayer -= _tookDamage;
                Destroy(fireBall.gameObject);

                if (_healthPlayer <= 0)
                    Die();
            }

        if (collision.TryGetComponent(out Heart heart))
        {
            _healthPlayer += _tookHealth;
            Destroy(heart.gameObject);

            if (_healthPlayer >= _tookHealth)
                _healthPlayer = _maxHealth;
        }
    }

        private void Die()
        {
            Destroy(gameObject);
        }
    }