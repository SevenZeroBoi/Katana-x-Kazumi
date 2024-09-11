using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacters", menuName = "ScriptableObjects/PlayerStats", order = 0)]

public class SO_PlayerStats : ScriptableObject
{
    public string characterName;
    public string characterDescription;
    public float chracterMoveSpeed;
    public float skillCooldown;

}
