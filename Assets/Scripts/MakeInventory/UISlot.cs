using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;

    private Item itemData;

    public void SetItem(Item item)
    {
        itemData = item;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemName.text = itemData.name;
        }
    }
    
}
