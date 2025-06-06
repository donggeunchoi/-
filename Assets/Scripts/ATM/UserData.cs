using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    //해당 클래스에 속성(프로퍼티)
    public string Name;
    public ulong Money;
    public ulong Balance;
    

    //생성자, 처음만들어질때 이 부분이 자동적으로 호출
    public UserData(string name, ulong money, ulong balance)//매개변수 3개
    {
        Name = name;
        Money = money;
        Balance = balance;
    }
    
}
