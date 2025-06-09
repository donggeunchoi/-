using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;

    private Item itemData;

    public void SetItem(Item item)
    {
        Debug.Log("여기는 괜찮아?");//여기는 굿
        itemData = item;
        RefreshUI();
    }

    public void RefreshUI()
    {
        Debug.Log("그럼 여기는?");//여기까지는 들어오네
        
        if (itemData != null)//이쪽으로 아이예들어오지 않는데?
        {
            Debug.Log($"$아이고{itemData.Icon}");
            
            if (itemData.Icon != null)
            {
                itemIcon.sprite = itemData.Icon;
                itemIcon.enabled = true;
            }
            else
            {
                Debug.Log("오호 리젝");
                itemIcon.enabled = false;
                itemIcon.sprite = null;
            }
            // itemName.text = itemData.name;
        }
        else
        {
            Debug.Log("여기로빠지니까 안되는 거겠지?");//정답
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }
    
}
