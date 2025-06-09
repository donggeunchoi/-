using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    //해당 필요 선언
    public string Name;
    public int Level;
    public int Attack;
    public int Defense;
    public int HP;
    public int Critical;

    //캐릭터 생성자 생성.
    public Character(string name,int level, int attack, int defense, int hp, int critical)
    {
        Name = name;
        Level = level;
        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;
    }
}
