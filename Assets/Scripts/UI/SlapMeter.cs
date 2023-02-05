using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapMeter : MonoBehaviour
{
    [SerializeField] private BattleUI battleUI;
    [SerializeField] private GameObject SlapUI;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private FighterStats playerStats, enemyStats;
    [SerializeField] private GameObject stopper;

    private void Update()
    {
        // Make sure we know who the Enemy is
        if (enemyStats == null) 
        {
            var enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null) 
            {
                enemyStats = enemy.GetComponent<FighterStats>();
            }
        }

        if (SlapUI.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))) 
        {
            //Debug.DrawRay(stopper.transform.position, new Vector3(0, 0, 20), Color.white, 1f);
            float atkMultiplier = 1;

            if (Physics.Raycast(stopper.transform.position, new Vector3(0, 0, 1), out var hit))
            {
                var str = hit.transform.gameObject.GetComponent<SlapArea>();
                if (str.slapStrength == SlapStrength.bad)
                {
                    atkMultiplier = 0.5f;
                }
                else if (str.slapStrength == SlapStrength.medium)
                {
                    atkMultiplier = 1f;
                }
                else if (str.slapStrength == SlapStrength.perfect)
                {
                    atkMultiplier = 2f;
                }

                SlapUI.SetActive(false);
                playerAnim.SetTrigger("slap");
                StartCoroutine(ExecuteCombat(atkMultiplier));
            }
        }
    }

    private IEnumerator ExecuteCombat(float atkMultiplier) 
    {
        // Wait time till slap
        yield return new WaitForSeconds(0.160f + 0.160f * 4);

        enemyStats.CurrentHp -= playerStats.Atk * playerStats.CurrentAtk * atkMultiplier;

        // Wait time after slap
        yield return new WaitForSeconds(0.160f + 0.160f * 5 + 1.160f);

        // Wait for enemy recovery
        yield return new WaitForSeconds(0.160f * 5);

        //Debug.Log(playerStats.Atk * playerStats.CurrentAtk * atkMultiplier);
        //Debug.Log(hit.transform.gameObject);

        //End the Player's turn
        if (enemyStats.CurrentHp > 0)
        {
            turnManager.Turn = Turn.enemy;
        }
        else 
        {
            battleUI.HasWon = true;
            victoryUI.SetActive(true);
            battleUI.ShowText("Shadow Professor Oak has been defeated! You are the champion of TreeSlap Tournament 2023 and will forever remain in the Hall of Fame!");
            // Victory!
        }
    }
}
