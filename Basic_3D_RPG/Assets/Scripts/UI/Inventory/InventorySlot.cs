using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �κ��丮 ���� UI�� ����ϴ� ������Ʈ�Դϴ�.
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
