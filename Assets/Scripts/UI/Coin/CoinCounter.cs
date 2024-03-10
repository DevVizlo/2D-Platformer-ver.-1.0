using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinCounter : MonoBehaviour
{
    [SerializeField] int _forOneCoin = 1;
    private int _quantityCoin = 0;
    private Text _textBar;

    private void Start()
    {
        _textBar = GetComponent<Text>();
    }

    public void GetCoin()
    {
        _quantityCoin += _forOneCoin;

        _textBar.text = Convert.ToString(_quantityCoin);
    }
}
