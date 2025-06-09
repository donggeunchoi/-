using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }

    public Item(string name, Sprite icon)
    {
        Name = name;
        Icon = icon;
    }
   
}
