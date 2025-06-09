using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite icon;

    public Item(string name, Sprite icon)
    {
        itemName = name;
        this.icon = icon;
    }
   
}
