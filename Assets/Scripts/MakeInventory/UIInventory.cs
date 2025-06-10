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
    
    private List<UISlot> _slotList = new List<UISlot>();
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    void BackButton()
    {
        InventoryManager.Instance.UIInventoryPanel.SetActive(false);
    }

    public void InitInventoryUI(List<Item> inventory)
    {
        foreach (UISlot slot in _slotList)
        {
            Destroy(slot.gameObject); 
        }
        _slotList.Clear();


        int slotCount = 10;

        for (int i = 0; i < slotCount; i++)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);
            if (i < inventory.Count)
            {
                Debug.Log($"{i},{inventory[i].Icon}");
                newSlot.SetItem(inventory[i]);
            }
            else
            {
                newSlot.SetItem(null);
            }
            _slotList.Add(newSlot);
        }
    }

    public void RefreshAllSlots()
    {
        foreach (UISlot slot in _slotList)
        {
            slot.RefreshUI();
        }
    }
    
}
