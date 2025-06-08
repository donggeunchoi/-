using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("UI 연결")] 
    [SerializeField] public GameObject UIMainMenu;
    [SerializeField] public GameObject UIStatus;
    [SerializeField] public GameObject UIInventory;
    
    //싱글톤 만들기
    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
}
