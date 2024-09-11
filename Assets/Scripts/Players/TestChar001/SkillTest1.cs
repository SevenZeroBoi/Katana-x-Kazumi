using UnityEngine;

public class SkillTest1 : MonoBehaviour
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
        ResetAnimation();
    }

    private void Update()
    {
        AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("skillattackin") && animState.normalizedTime >= 1.0f && !isCompleted)
        {
            anim.SetTrigger("attacking2");
            isCompleted = true;
            box.enabled = false;
            box.enabled = true;
        }
        else if (animState.IsName("skillstop") && animState.normalizedTime >= 1.0f)
        {
            ObjectPool.Instance.ReturnToPool("Skill1", gameObject);
        }
    }

    private void ResetAnimation()
    {
        if (anim != null)
        {
            anim.Play("skillattackin");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            MainEnemiesScript.Instance.Attacking(Random.Range(50,90),1.2f,1.1f);
        }
    }
}
