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
    
    //싱글톤 만들기
    public static InventoryManager Instance { get; private set; }
    
    
    public Player player { get; private set; }
    
    

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

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
            //플레이어 정보 집어 넣기
        Character character = new Character("스파르타", 11, 35, 40, 100, 25);
        player = new Player(character);

        UIManager.Instance.SetAllUI(player.Character);
       
    }
    
}
