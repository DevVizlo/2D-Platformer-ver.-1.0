using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [Header("Объект, позиции спавна")]
    [SerializeField] private ObjectMove _object;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();

        for (int i = 0; i < _spawnPoints.Length; i++) 
        {
            Instantiate(_object, _spawnPoints[i]);
        }
    }
}
