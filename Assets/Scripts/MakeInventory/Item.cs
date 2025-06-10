using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Critical { get;private set; }
    
    public bool EquipItem { get; set; }

    public Item(string name, Sprite icon,int attack,int defense,int critical)
    {
        Name = name;
        Icon = icon;
        EquipItem = false;
        Attack = attack;
        Defense = defense;
        Critical = critical;
    }
   
}
