using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    public UIMainMenu UIMainMenu { get; private set; }
    public UIStatus UIStatus { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            UIMainMenu = GetComponentInChildren<UIMainMenu>();
            UIStatus = GetComponentInChildren<UIStatus>();
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
