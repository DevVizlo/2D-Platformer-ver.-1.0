using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthCharacter _cheracter;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _cheracter.ChangedHealth += RefreshHeart;
    }

    private void OnDisable()
    {
        _cheracter.ChangedHealth -= RefreshHeart;
    }

    public void RefreshHeart()
    {
        _image.fillAmount = _cheracter.Health / _cheracter.MaxHealth;
    }
}
