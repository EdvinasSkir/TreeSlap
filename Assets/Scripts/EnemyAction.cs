using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private FighterStats enemyStats;

    private TurnManager turnManager;
    private FighterStats playerStats;
    private BattleUI battleUI;

    private bool enemyAttacking;

    private void Start()
    {
        if (turnManager == null)
        {
            battleUI = FindObjectOfType<BattleUI>();
        }

        if (turnManager == null) 
        {
            turnManager = FindObjectOfType<TurnManager>();
        }

        if (playerStats == null)
        {
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<FighterStats>();
        }
    }

    private void Update()
    {
        if (turnManager.Turn == Turn.enemy && !enemyAttacking) 
        {
            enemyAttacking = true;

            enemyAnim.SetTrigger("slap");

            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator EnemyTurn() 
    {
        // Wait time till slap
        yield return new WaitForSeconds(2.760f + 0.160f);

        playerStats.CurrentHp -= enemyStats.Atk;

        // Wait time after slap
        yield return new WaitForSeconds(2f);

        // Finish Enemy turn
        battleUI.ShowBattleUI();

        if (playerStats.CurrentHp > 0)
        {
            turnManager.Turn = Turn.player;
            enemyAttacking = false;
        }
        else 
        {
            battleUI.ShowText("You got slapped out! Come back in ten years...");
        }
    }
}
