using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인벤토리에 들어갈 아이템 데이터 구조입니다.
/// </summary>
[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public string description;
    public int Count;
}
