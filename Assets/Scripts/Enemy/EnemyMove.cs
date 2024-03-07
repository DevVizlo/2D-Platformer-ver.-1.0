using UnityEngine;

public class EnemyMove : MonoBehaviour
{
        [Header("Границы патруля")]
        [SerializeField] private Transform _path;
        [Header("Скорость передвижения")]
        [SerializeField] private float _speed;
        [Header("Объекты для взаимодействия")]
        [SerializeField] private Player _player;
        [SerializeField] private ChaseTriggerZone _playerTrigger; 

        private Transform[] _points;
        private int _currentPoint;

        private void Start()
        {
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }

        private void Update()
        {
            if(_playerTrigger._isPlayerDetected == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
            else if(_playerTrigger._isPlayerDetected == false)
            {
                Patrul();
            }
        }

       private void Patrul()
        {
            Transform target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;
                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
}