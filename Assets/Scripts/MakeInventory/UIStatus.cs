using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public Button backButton;
    
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI criticalText;
    
    void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    void BackButton()
    {
        InventoryManager.Instance.UIStatusPanel.SetActive(false);
    }

    public void SetCharacterInfo(Character character)
    {
        attackText.text = character.Attack.ToString();
        defenseText.text = character.Defense.ToString();
        hpText.text = character.HP.ToString();
        criticalText.text = character.Critical.ToString();
        
    }
}
