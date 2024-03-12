using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void RefreshHeart() => _image.fillAmount = _enemy.Health / _enemy.MaxHealth;
}
