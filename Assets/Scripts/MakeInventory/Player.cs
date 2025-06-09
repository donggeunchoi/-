using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character Character{get ; private set;}

    public Player(Character character)
    {
        Character = character;
    }
    
}
