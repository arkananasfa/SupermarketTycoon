using System;
using System.Collections.Generic;
using UnityEngine;

public class AdsBanner : MonoBehaviour, IImprovable
{

    public int MaxLevel => 100;
    public ObservableValue<int> MaxClientsCount = new(3);
    public float Price => (float)Math.Clamp(20f + 10f * Level * Math.Log(Level), 1, float.MaxValue);
    
    public List<(object, object, object)> DescriptionParameters => new ()
    {
        ("/header", "Icon_Banner", "Ads"),
        ("Max clients count", MaxClientsCount.Value, 3 + (int)Mathf.Sqrt(Math.Clamp(Level-3, 0, 1000))),
        ("Time between time", ToNextClientTime.ToString("F2"), ((float)Math.Clamp(10f - 2*Math.Log(Level+1), 0f, 10f)).ToString("F2"))
    };
    
    public float ToNextClientTime { get; set; }= 10f;
    
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            MaxClientsCount.Value = 3 + (int)Mathf.Sqrt(Math.Clamp(Level-4, 0, 1000));
            ToNextClientTime = (float)Math.Clamp(10f - 2*Math.Log(_level), 0f, 10f);
        }
    }
    
    private int _level = 1;

}