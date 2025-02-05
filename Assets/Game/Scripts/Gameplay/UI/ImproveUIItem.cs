using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImproveUIItem : MonoBehaviour
{

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _fullLineText;
    
    public void InitHeader(Sprite iconSprite, string titleText)
    {
        _icon.sprite = iconSprite;
        _titleText.text = titleText;
    }

    public void InitFullLine(string paramName, string from, string to)
    {
        string rightPart = !from.Equals(to) ? $"{from} > <color=#3E8755>{to}" : from;
        _fullLineText.text = $"{paramName}: {rightPart}";
    }
    
}