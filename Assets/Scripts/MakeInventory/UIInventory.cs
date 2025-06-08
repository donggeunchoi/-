using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    void BackButton()
    {
        InventoryManager.Instance.UIInventoryPanel.SetActive(false);
    }
    
}
