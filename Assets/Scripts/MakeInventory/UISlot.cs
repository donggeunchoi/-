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
            itemIcon.sprite = itemData.Icon;
            itemIcon.enabled = true;
            // itemName.text = itemData.name;
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }
    
}
