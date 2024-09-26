using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObjects/Skills", order = 0)]
public class SO_PlayerSkills : MonoBehaviour
{
    public Animation a;
    public int skillMinDamage;
    public int skillMaxDamage;
    

    /*
    public enum SkillType
    {
        COOLDOWNCHECK,COUNTSCHECK
    }*/
}
