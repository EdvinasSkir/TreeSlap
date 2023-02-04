using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterStatsUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FighterStats stats;

    private void Update()
    {
        slider.maxValue = stats.Hp;
        slider.value = stats.CurrentHp;
    }
}
