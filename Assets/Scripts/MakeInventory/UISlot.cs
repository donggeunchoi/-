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
    [SerializeField] private GameObject equippedMark;
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
        
        if (itemData != null && itemData.Icon != null)//이쪽으로 아이예들어오지 않는데?
        {
            
                itemIcon.sprite = itemData.Icon;
                itemIcon.enabled = true;

                if (itemData.EquipItem)
                {
                    equippedMark.SetActive(true);
                }
                else
                {
                    equippedMark.SetActive(false);
                }
           
        }
        else
        {
            Debug.Log("여기로빠지니까 안되는 거겠지?");//정답
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            equippedMark.SetActive(false);
        }
    }

    public void OnClickSlot()
    {
        if (itemData == null)
        {
            return;
        }

        if (itemData.EquipItem)
        {
            itemData.EquipItem = false;
            InventoryManager.Instance.player.Character.Unequip(itemData);
        }
        else
        {
            itemData.EquipItem = true;
            InventoryManager.Instance.player.Character.Equip(itemData);
        }
        
        RefreshUI();
        UIManager.Instance.UIStatus.SetCharacterInfo(InventoryManager.Instance.player.Character);
    }
    
}
