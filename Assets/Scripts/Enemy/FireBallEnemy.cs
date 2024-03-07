using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class FireBallEnemy : MonoBehaviour
    {
        [SerializeField] private float _timeDestroy = 5f;
        [SerializeField] private float _speed = 3f;

        private Vector3 _startPositionTarget;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void Start()
        {
        _startPositionTarget = _target.position;
        Invoke(nameof(DestrroyFireBall), _timeDestroy);
    }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPositionTarget, _speed * Time.deltaTime);
        }

        private void DestrroyFireBall()
        {
            Destroy(gameObject);
        }
    }
