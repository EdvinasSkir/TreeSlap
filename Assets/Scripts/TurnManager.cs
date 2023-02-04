using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn 
{
    player,
    enemy
}

public class TurnManager : MonoBehaviour
{
    public Turn Turn;
}
