using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReaction : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private Animator playerAnim;
    private Animator enemyAnim;

    private void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        enemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    public void SlapEnemy() 
    {
        audio.Play();
        enemyAnim.SetTrigger("isDamaged");
    }

    public void SlapPlayer() 
    {
        audio.Play();
        playerAnim.SetTrigger("isDamaged");
    }
}
