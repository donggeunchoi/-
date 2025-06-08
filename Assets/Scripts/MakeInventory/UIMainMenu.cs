using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
  public void OpenMainMenu()
  {
    InventoryManager.Instance.UIMainMenu.SetActive(true);
  }

  public void OpenStatus()
  {
    InventoryManager.Instance.UIStatus.SetActive(true);
  }

  public void OpenInventory()
  {
    InventoryManager.Instance.UIInventory.SetActive(true);
  }

  public void CloseInventory()
  {
    InventoryManager.Instance.UIInventory.SetActive(false);
  }

  public void CloseStatus()
  {
    InventoryManager.Instance.UIStatus.SetActive(false);
  }
}
