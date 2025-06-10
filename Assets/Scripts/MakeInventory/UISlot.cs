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
        
        if (itemData.EquipItem == false)
        {
            //장착시도
            if (InventoryManager.Instance.player.Character.EquippedItem != null)
            {
                Debug.Log("기본에 있던 장비 해제 완료했데이");
                //장비가 이미 있으니 해제 시키기
                InventoryManager.Instance.player.Character.Unequip(InventoryManager.Instance.player.Character.EquippedItem);
                InventoryManager.Instance.player.Character.EquippedItem.EquipItem = false;
            }
            Debug.Log("장비장착완료");
            itemData.EquipItem = true;
            InventoryManager.Instance.player.Character.Equip(itemData);
            InventoryManager.Instance.player.Character.EquippedItem = itemData;

        }
        else
        {
            //해제
            itemData.EquipItem = false;
            InventoryManager.Instance.player.Character.Unequip(itemData);
            InventoryManager.Instance.player.Character.EquippedItem = null;
        }
        
        RefreshUI();
        UIManager.Instance.UIStatus.SetCharacterInfo(InventoryManager.Instance.player.Character);
        UIManager.Instance.UIInventory.RefreshAllSlots();
    }
    
}
