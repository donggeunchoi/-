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


    [Header("무기 이미지")] public Sprite swordSprite;
    public Sprite weapon1Sprite;
    public Sprite weapon2Sprite;
    
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

        Item item1 = new Item("소드", swordSprite,10,1,5);
        Item item2 = new Item("무기2", weapon1Sprite,20,2,3);
        Item item3 = new Item("무기3", weapon2Sprite,5,4,6);
        
        player.Character.AddItem(item1);
        player.Character.AddItem(item2);
        player.Character.AddItem(item3);
        
        
        UIManager.Instance.SetAllUI(player.Character);
        
        UIManager.Instance.UIInventory.InitInventoryUI(player.Character.Inventory);
       
    }
    
}
