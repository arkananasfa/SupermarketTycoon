using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImproveUI : MonoBehaviour
{

    private static ImproveUI _instance;
    
    [SerializeField] private ImproveUIItem _itemPrefab;
    [SerializeField] private RectTransform _toDownHandler;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Transform _itemsContainer;
    
    private List<ImproveUIItem> _items = new();

    private IImprovable _improvable;
    
    public static void Open(IImprovable improvable)
    {
        _instance._improvable = improvable;
        _instance.ClearItems();
        _instance.CreateUI();
        _instance.Show();
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Show()
    {
        _itemsContainer.gameObject.SetActive(true);
    }

    private void CreateUI()
    {
        var parameters = _improvable.GetDescriptionParameters();
        FindHeader(parameters);
        foreach (var param in parameters)
        {
            if (param.Item1.ToString()[0] == '/')
                continue;
            
            ImproveUIItem item = Instantiate(_itemPrefab, _itemsContainer);
            item.InitFullLine(param.Item1.ToString(), param.Item2.ToString(), param.Item3.ToString());
            _items.Add(item);
        }
        _toDownHandler.SetSiblingIndex(_itemsContainer.childCount-1);
        _button.gameObject.SetActive(_improvable.Level != _improvable.MaxLevel);
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(ImproveButtonClick);
    }

    private void FindHeader(List<(object, object, object)> args)
    {
        var objs = args.FirstOrDefault(arg => arg.Item1.ToString() == "/header");
        if (objs != default)
        {
            ImproveUIItem item = Instantiate(_itemPrefab, _itemsContainer);
            item.InitHeader(Resources.Load<Sprite>($"{objs.Item2}"), objs.Item3.ToString());
            _items.Add(item);
        } 
    }

    private void ClearItems()
    {
        for(int i = _items.Count - 1; i >= 0; i--)
            Destroy(_items[i].gameObject);
        _items.Clear();
    }

    private void ImproveButtonClick()
    {
        ClearItems();
        _improvable.Improve();
        CreateUI();
    }
    
}