using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinCounter : MonoBehaviour
{
    [SerializeField] private int _CoinValue = 1;
    private int _quantityCoin = 0;
    private Text _textBar;

    private void Awake()
    {
        _textBar = GetComponent<Text>();
    }

    public void ReceivCoin()
    {
        _quantityCoin += _CoinValue;

        _textBar.text = Convert.ToString(_quantityCoin);
    }
}
