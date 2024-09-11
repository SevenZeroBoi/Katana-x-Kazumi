using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayerScripts : MonoBehaviour
{
    public SO_PlayerStats pStats;
    public enum playerStates
    {
        IDLE,
        MOVING,
        USINGSKILL,
        CUTSCENE
    }

}
