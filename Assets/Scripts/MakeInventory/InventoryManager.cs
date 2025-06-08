using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("UI 연결")] 
    [SerializeField] public GameObject UIMainMenuPanel;
    [SerializeField] public GameObject UIStatusPanel;
    [SerializeField] public GameObject UIInventoryPanel;
    
    
    //프로퍼티 선언
    public UIMainMenu UIMainMenu { get; private set; }
    public UIStatus UIStatus { get; private set; }
    public UIInventory UIInventory { get; private set; }
    
    //싱글톤 만들기
    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            //초기화.
            UIMainMenu = UIMainMenuPanel.GetComponent<UIMainMenu>();
            UIStatus =  UIStatusPanel.GetComponent<UIStatus>();
            UIInventory = UIInventoryPanel.GetComponent<UIInventory>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
}
