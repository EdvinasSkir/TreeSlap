using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private Object titleScene;
    [SerializeField] private FighterStats playerStats;
    [SerializeField] private GameObject textBox;
    [SerializeField] private TMP_Text textBoxText;
    [SerializeField] private GameObject statsPlayer, statsEnemy;
    [SerializeField] private GameObject battleUI, attackUI;
    [SerializeField] private GameObject slapMeter;

    [HideInInspector] public bool HasWon;
    private bool textIsShowing;

    private void Update()
    {
        // Finish reading text if it's on-screen
        if (textIsShowing && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (HasWon) 
            {
                SceneManager.LoadSceneAsync("Title");
            }
            else if (!playerStats.isDead)
            {
                textIsShowing = false;
                ShowBattleUI();
                statsPlayer.SetActive(true);
                statsEnemy.SetActive(true);
            }
            else 
            {
                SceneManager.LoadSceneAsync("Title");
            }

        }

        // Close deeper Battle menus
        if (Input.GetKeyDown(KeyCode.Mouse1) && !textIsShowing) 
        {
            ShowBattleUI();
        }
    }

    // Show Text Box
    public void ShowText(string text) 
    {
        // Disable all UI except Text
        statsPlayer.SetActive(false);
        statsEnemy.SetActive(false);
        battleUI.SetActive(false);
        attackUI.SetActive(false);
        slapMeter.SetActive(false);

        // Enable ONLY Text
        textBox.SetActive(true);
        textBoxText.text = text;
        textIsShowing = true;
    }

    // Return to lowest BattleUI
    public void ShowBattleUI() 
    {
        textBox.SetActive(false);

        attackUI.SetActive(false);
        battleUI.SetActive(true);
    }

    public void FightButton() 
    {
        battleUI.SetActive(false);
        attackUI.SetActive(true);
    }

    public void ItemsButton() 
    {
        ShowText("You have no items!");
    }

    public void RunButton() 
    {
        ShowText("You have nowhere to run.");
    }

    // Attacks
    public void Attack(float power) 
    {
        battleUI.SetActive(false);
        attackUI.SetActive(false);

        slapMeter.SetActive(true);
        playerStats.CurrentAtk = power;
    }
}
