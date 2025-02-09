using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImproveUIItem : MonoBehaviour
{

    [Header("Content")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _fullLineText;

    [Header("Height settings")] 
    [SerializeField] private float _headerHeight;
    [SerializeField] private float _fullLineHeight;
    
    public void InitHeader(Sprite iconSprite, string titleText)
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _headerHeight);
        _fullLineText.gameObject.SetActive(false);
        _icon.sprite = iconSprite;
        _titleText.text = titleText;
    }

    public void InitFullLine(string paramName, string from, string to)
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _fullLineHeight);
        _icon.gameObject.SetActive(false);
        _titleText.gameObject.SetActive(false);
        string rightPart = !from.Equals(to) ? $"{from} > <color=#3E8755>{to}" : from;
        _fullLineText.text = $"{paramName}: {rightPart}";
    }
    
}