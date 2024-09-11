using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemies", menuName = "ScriptableObjects/Enemies", order = 1)]
public class SO_Enemies : ScriptableObject
{
    public string enemyName;
    public float enemyHealth;

}
