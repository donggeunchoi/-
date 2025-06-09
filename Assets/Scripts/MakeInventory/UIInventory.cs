using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button backButton;

    //슬롯 프리펩
    [SerializeField] private UISlot slotPrefab;
    //컨텐츠 연결.
    [SerializeField] private Transform slotParent;
    
    private List<UISlot> slotList = new List<UISlot>();
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        backButton.onClick.AddListener(BackButton);
        // InitInventoryUI();
    }

    void BackButton()
    {
        InventoryManager.Instance.UIInventoryPanel.SetActive(false);
    }

    public void InitInventoryUI(List<Item> inventory)
    {
        foreach (UISlot slot in slotList)
        {
            Destroy(slot.gameObject); 
        }
        slotList.Clear();


        int slotCount = 10;

        for (int i = 0; i < slotCount; i++)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);
            if (i < inventory.Count)
            {
                newSlot.SetItem(inventory[i]);
            }
            else
            {
                newSlot.SetItem(null);
            }
            slotList.Add(newSlot);
        }
        
        
        
        
        // for (int i = 0; i < 10; i++)
        // {
        //     // 가짜 아이템 데이터 생성
        //     Item fakeItem = new Item($"Item {i+1}", null);  // 아이콘은 null 일단 테스트용
        //
        //     UISlot newslot = Instantiate(slotPrefab, slotParent);
        //     // SetItem 호출
        //     newslot.SetItem(fakeItem);
        //     slotList.Add(newslot);
        //     
        //
        //     
        // }
    }
    
}
