using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    public float Hp = 10;
    public float Atk = 2;

    public float CurrentHp, CurrentAtk;

    private void Start()
    {
        CurrentHp = Hp;
        CurrentAtk = Atk;
    }
}
