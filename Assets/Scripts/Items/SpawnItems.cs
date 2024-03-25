using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [Header("Объект, позиции спавна")]
    [SerializeField] private ObjectMove _item;
    [SerializeField] private Transform _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
            Instantiate(_item, _spawnPoints.GetChild(i));
    }
}
