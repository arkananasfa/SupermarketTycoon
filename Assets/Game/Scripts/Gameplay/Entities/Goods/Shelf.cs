using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GoodsType Type { get; private set; }
    public int MaxGoods { get; private set; } = 6; // Each shelf can hold 6 goods
    public int CurrentGoods { get; private set; }

    public GameObject goodGameObject { get; private set; }

    private GoodsTypeSection _section;

    public void Initialize(GoodsTypeSection section, GoodsType type)
    {
        _section = section;
        goodGameObject = transform.GetChild(0).gameObject;
        
        Type = type;
        MaxGoods = transform.childCount;
        CurrentGoods = MaxGoods;

        for (int i = 0; i < MaxGoods; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public bool TakeGood()
    {
        if (CurrentGoods > 0)
        {
            CurrentGoods--;
            GameObject go = transform.GetChild(CurrentGoods).gameObject;
            go.SetActive(false);
            _section.AddMissingGoodShelf(this);

            return true;
        }
        return false;
    }

    public void Restock()
    {
        CurrentGoods++;
        for (int i = 0; i < MaxGoods; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if (go.activeSelf == false)
            {
                go.SetActive(true);
                break;
            }
        }
        
    }
}