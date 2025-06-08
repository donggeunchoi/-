using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
  public TextMeshProUGUI nameText;
  public TextMeshProUGUI levelText;

  #region UI 이동 

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

  #endregion

  public void SetCharacterInfo(Character character)
  {
    nameText.text = character.Name;
    levelText.text = character.Level.ToString();
  }
  
  
}
