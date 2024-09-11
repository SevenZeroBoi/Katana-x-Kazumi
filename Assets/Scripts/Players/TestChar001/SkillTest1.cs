using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillTest1 : MonoBehaviour
{

    public Animator anim;
    public BoxCollider2D box;

    public bool isCompleted = false;
    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            
        }

        AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo(0);
        if (animState.normalizedTime >= 1.0f && !isCompleted)
        {
            anim.SetTrigger("attacking2");
            box.enabled = false;
            box.enabled = true;
            isCompleted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        }
    }
}
