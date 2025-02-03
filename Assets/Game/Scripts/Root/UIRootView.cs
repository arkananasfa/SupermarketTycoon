using UnityEngine;

public class UIRootView : MonoBehaviour
{
    
    [SerializeField] private GameObject loadingScreen;

    private void Awake()
    {
        SetLoaderActive(false);
    }

    public void SetLoaderActive(bool active)
    {
        loadingScreen.SetActive(active);
    }
    
}