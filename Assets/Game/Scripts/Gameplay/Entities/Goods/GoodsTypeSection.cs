using System;
using System.Collections.Generic;
using UnityEngine;

public class GoodsTypeSection : MonoBehaviour, IImprovable
{

    public int MaxLevel => _maxLevel;
    public ObservableValue<Shelf> MissingGoodShelf = new();
    public List<Shelf> AvaiableShelves = new();
    public float Price => (float)Math.Clamp(_startPrice + _multiplyPrice * Level * Math.Log(Level), 1, float.MaxValue);
    public float GetProductPrice(int level) => _startProductPrice + _additionalProductPrice * level;
    
    public List<(object, object, object)> DescriptionParameters => new ()
    {
        ("/header", $"Icon_{_type.ToString()}", $"{_type.ToString()} section"),
        ("Shelves count", AvaiableShelves.Count, AvaiableShelves.Count + (_newShelvesLevels.Contains(Level+1) ? 1 : 0)),
        ("Product price", GetProductPrice(Level), GetProductPrice(Level+1))
    };

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            if (_newShelvesLevels.Contains(value))
                ActivateShelf(_shelves[_newShelvesLevels.IndexOf(value)]);
        }
    }

    public Transform FreezerTransform => _freezer.transform;
    
    [Header("Improve Settings")]
    [SerializeField] private GoodsType _type;
    [SerializeField] private List<int> _newShelvesLevels;
    [SerializeField] private int _maxLevel = 100;
    
    [Header("Objects")]
    [SerializeField] private GameObject _freezer;
    [SerializeField] private List<Shelf> _shelves;
    [SerializeField] private GameObject _noShelvesGO;

    [Header("Improve Price")]
    [SerializeField] private float _startPrice;
    [SerializeField] private float _multiplyPrice;
    
    [Header("Product Price")]
    [SerializeField] private float _startProductPrice;
    [SerializeField] private float _additionalProductPrice;

    
    private List<Shelf> _missingGoodShelves = new ();
    private int _level = 1;

    private void Start()
    {
        if (AvaiableShelves.Count == 0)
        {
            
            _level = 0;
        }
        foreach (Shelf shelf in _shelves)
        {
            shelf.Initialize(this, _type);
        }
    }
    
    public void Improve()
    {
        Level++;
        if (_noShelvesGO != null)
            _noShelvesGO.SetActive(false);
    }

    private void ActivateShelf(Shelf shelf)
    {
        shelf.gameObject.SetActive(true);
        AvaiableShelves.Add(shelf);
    }

    public void AssignWorker(Worker worker)
    {
        MissingGoodShelf.OnValueChanged += worker.RestockShelf;
    }

    public void AddMissingGoodShelf(Shelf shelf)
    {
        if (MissingGoodShelf.Value == null)
        {
            MissingGoodShelf.Value = shelf; 
        }
        else
        {
            _missingGoodShelves.Add(shelf);
        }
    }

}