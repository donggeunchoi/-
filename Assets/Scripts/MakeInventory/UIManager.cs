using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    public UIMainMenu UIMainMenu { get; private set; }
    public UIStatus UIStatus { get; private set; }
    public UIInventory UIInventory { get; private set; }
    
    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
           UIMainMenu = uiMainMenu;
           UIStatus = uiStatus;
           UIInventory = uiInventory;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetAllUI(Character character)
    {
        UIMainMenu.SetCharacterInfo(character);
        UIStatus.SetCharacterInfo(character);
    }
}
