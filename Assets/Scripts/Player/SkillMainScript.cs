using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillMainScript : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D box;

    public bool isCompleted = false;

    private void OnEnable()
    {
        isCompleted = false;
        if (box != null)
        {
            box.enabled = true;
        }

        if (anim != null)
        {
            anim.Play("AttackStart");
        }
    }
    private void Update()
    {
        AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("AttackEnd") && animState.normalizedTime >= 0.1f)
        {
            PoolingManager.Instance.ReturnToPool("Skill1", gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            
        }
    }
}
