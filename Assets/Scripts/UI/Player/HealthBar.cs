using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void RefreshHeart()
    {
        _image.fillAmount = _player.Health / _player.MaxHealth;
    }
}
