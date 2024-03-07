using System.Collections;
using UnityEngine;

public class SpawnFairBall : MonoBehaviour
{
        [Header("Время перезарядки")]
        [SerializeField] private float _timeSpawn = 2f;
        [SerializeField] private Enemy _enemy;
        
        private Coroutine _coroutine;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                _coroutine = StartCoroutine(Spawn());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                if (_coroutine != null)
                    StopCorutin();
            }
        }

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_timeSpawn);

            while (true)
            {
                yield return wait;

                FireBallEnemy moverToTarget = Instantiate(_enemy.ReceiveBall, _enemy.transform.position, Quaternion.identity);
                moverToTarget.SetTarget(_enemy.ReceiveBallTarget);
            }
        }

    private void StopCorutin()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
