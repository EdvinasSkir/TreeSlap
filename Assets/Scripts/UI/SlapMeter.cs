using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapMeter : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            //Debug.DrawRay(stopper.transform.position, new Vector3(0, 0, 20), Color.white, 1f);

            if (Physics.Raycast(stopper.transform.position, new Vector3(0, 0, 1), out var hit)) 
            {
                float atkMultiplier = 1;
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

                enemyStats.CurrentHp -= playerStats.Atk * playerStats.CurrentAtk * atkMultiplier;

                //Debug.Log(playerStats.Atk * playerStats.CurrentAtk * atkMultiplier);
                //Debug.Log(hit.transform.gameObject);

                //End the Player's turn
                turnManager.Turn = Turn.enemy;
                gameObject.SetActive(false);
            }
        }
    }

    
}
