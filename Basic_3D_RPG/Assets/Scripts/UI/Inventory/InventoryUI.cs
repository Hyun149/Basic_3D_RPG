using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �κ��丮 UI ������ Ǯ���� ������ �ڵ� �����ϴ� ������ �մϴ�.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }

    [SerializeField] private Transform slotParent;
    [SerializeField] private int initialSlotCount = 20;

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
        for (int i = 0; i < initialSlotCount; i++)
        {
            GameObject slotObj = ObjectPoolManager.Instance.Spawn(PoolType.InventorySlot, Vector3.zero, Quaternion.identity);
            slotObj.transform.SetParent(slotParent, false);
            slotObj.SetActive(true);
        }
    }

    public void CreateSlot(Item item)
    {
        GameObject slotObj = ObjectPoolManager.Instance.Spawn(PoolType.InventorySlot, Vector3.zero, Quaternion.identity);
        slotObj.transform.SetParent(slotParent, false);

        var slot = slotObj.GetComponent<InventorySlot>();
        slot.SetItem(item);
    }

    public void ClearSlot()
    {
        foreach (Transform child in slotParent)
        {
            ObjectPoolManager.Instance.ReturnToPool(PoolType.InventorySlot, child.gameObject);
        }
    }
}
