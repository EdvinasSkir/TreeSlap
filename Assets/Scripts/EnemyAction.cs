using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private FighterStats enemyStats, playerStats;

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
            EnemyTurn();
        }
    }

    private void EnemyTurn() 
    {
        playerStats.CurrentHp -= enemyStats.Atk;

        // Finish Enemy turn
        battleUI.ShowBattleUI();

        turnManager.Turn = Turn.player;
        enemyAttacking = false;
    }
}
