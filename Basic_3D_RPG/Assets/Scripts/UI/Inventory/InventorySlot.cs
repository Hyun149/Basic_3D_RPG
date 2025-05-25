using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 인벤토리 슬롯 UI를 담당하는 컴포넌트입니다.
/// </summary>
public class InventorySlot : MonoBehaviour, IPoolable
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemNameText;

    private Item currentItem;

    public void SetItem(Item item)
    {
        currentItem = item;
        icon.sprite = item.icon;
        itemNameText.text = item.itemName;
    }

    public void OnSpawn()
    {
        icon.sprite = null;
        itemNameText.text = string.Empty;
    }

    public void OnDespawn()
    {
        currentItem = null;
    }
}
