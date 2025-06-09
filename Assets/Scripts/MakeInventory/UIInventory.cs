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
        InitInventoryUI();
    }

    void BackButton()
    {
        InventoryManager.Instance.UIInventoryPanel.SetActive(false);
    }

    public void InitInventoryUI()
    {
        for (int i = 0; i < 10; i++)
        {
            UISlot newslot = Instantiate(slotPrefab, slotParent);
            slotList.Add(newslot);
            
        }
    }
    
}
