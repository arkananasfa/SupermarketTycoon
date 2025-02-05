using System;
using UnityEngine;

public class ImprovableClickHandler : MonoBehaviour
{

    private IImprovable _improvable;

    private void Awake()
    {
        _improvable = GetComponent<IImprovable>();
    }

    private void OnMouseDown()
    {
        Debug.Log(name + " clicked");
    }
    
}