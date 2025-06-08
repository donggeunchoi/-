using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
  public void OpenMainMenu()
  {
    InventoryManager.Instance.UIMainMenuPanel.SetActive(true);
  }

  public void OpenStatus()
  {
    InventoryManager.Instance.UIStatusPanel.SetActive(true);
  }

  public void OpenInventory()
  {
    InventoryManager.Instance.UIInventoryPanel.SetActive(true);
  }
  
}
