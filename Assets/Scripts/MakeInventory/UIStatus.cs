using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    void BackButton()
    {
        InventoryManager.Instance.UIStatusPanel.SetActive(false);
    }
}
