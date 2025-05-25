using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인벤토리 아이템 리스트를 관리하고 슬롯에 아이템을 할당합니다.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    [SerializeField] private List<Item> testItem;

    private List<Item> itemList = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (var item in testItem)
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        itemList.Add(item);
        InventoryUI.Instance.CreateSlot(item);
    }
}
