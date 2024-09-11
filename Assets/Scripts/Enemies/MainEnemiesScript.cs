using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemiesScript : MonoBehaviour
{
    public float Health;

    public static MainEnemiesScript Instance;

    private void Awake()
    {
        Instance = this;
        //Instance = GameObject.FindGameObjectWithTag("Boss").GetComponent<MainEnemiesScript>();
    }

    public void Attacking(int damage, params float[] multiplier)
    {
        float totalDamage = damage;
        
        if (multiplier != null)
        {
            foreach (float multi in multiplier)
            {
                totalDamage *= multi;
            }
        }

        int finalDamage = Mathf.CeilToInt(totalDamage);
        Health -= finalDamage;
        Debug.LogError("ATTTACK" + Health);
    }

    public void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
