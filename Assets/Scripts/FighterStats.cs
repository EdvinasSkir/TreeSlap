using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public float Hp = 10;
    public float Atk = 2;

    public float CurrentHp, CurrentAtk;

    [HideInInspector] public bool isDead;

    private void Start()
    {
        CurrentHp = Hp;
        CurrentAtk = Atk;
    }

    private void Update()
    {
        if (CurrentHp <= 0) 
        {
            if (!isDead) 
            {
                isDead = true;
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        anim.SetTrigger("dead");
        yield return new WaitForSeconds(3f);
    }

}
