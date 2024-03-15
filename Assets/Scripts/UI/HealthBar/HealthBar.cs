using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthCharacter _cheracter;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _cheracter.ChangingHealth += RefreshHeart;
    }

    private void OnDisable()
    {
        _cheracter.ChangingHealth -= RefreshHeart;
    }

    public void RefreshHeart()
    {
        _image.fillAmount = _cheracter.Health / _cheracter.MaxHealth;
    }
}
