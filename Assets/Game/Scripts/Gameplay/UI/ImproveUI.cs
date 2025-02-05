using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImproveUI : MonoBehaviour
{

    [SerializeField] private ImproveUIItem _itemPrefab;
    [SerializeField] private RectTransform _toDownHandler;
    [SerializeField] private Button _button;

    private IImprovable _improvable;

    public void Init(IImprovable improvable)
    {
        _improvable = improvable;
        CreateUI(improvable);
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener();
    }

    public void CreateUI(IImprovable improvable)
    {
        FindHeader(improvable.DescriptionParameters);
        foreach (var param in improvable.DescriptionParameters)
        {
            ImproveUIItem item = Instantiate(_itemPrefab, transform);
            item.InitFullLine(param.Item1.ToString(), param.Item2.ToString(), param.Item3.ToString());
        }
        _toDownHandler.SetSiblingIndex(transform.childCount-1);
    }

    private void FindHeader(List<(object, object, object)> args)
    {
        var objs = args.FirstOrDefault(arg => arg.Item1 == "/header");
        if (objs != default)
        {
            ImproveUIItem item = Instantiate(_itemPrefab, transform);
            item.InitHeader(Resources.Load<Sprite>($"Icons/{objs.Item2}"), objs.Item3.ToString());
        } 
    }
    
}