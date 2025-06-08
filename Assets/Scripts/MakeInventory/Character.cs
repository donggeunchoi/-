using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //해당 필요 선언
    public int Attack;
    public int Defense;
    public int HP;
    public int Critical;

    //캐릭터 생성자 생성.
    public Character(int attack, int defense, int hp, int critical)
    {
        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;
    }
}
