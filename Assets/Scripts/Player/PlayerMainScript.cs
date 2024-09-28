using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMainScript : MonoBehaviour
{
    public float pMoveSpeed;
    [HideInInspector] public float currentMoveSpeed;

    public GameObject skillPrefabS0;
    public GameObject skillPrefabS1;
    public GameObject skillPrefabS2;

    public float skillCooldown;
    private float _currentSkillCooldown;
    private bool _isSkillCooldown = false;

    public Animator pAnim;
    private int _movementAnim; //0 - Idle/1 - MoveFront/-1 - MoveBack

    void Movements()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.position = transform.position + new Vector3(moveX, moveY).normalized * Time.deltaTime * currentMoveSpeed;
    }

    private void Start()
    {
        currentMoveSpeed = pMoveSpeed;
    }

    private void Update()
    {
        if (!_isSkillCooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                UsingSkillSlot0();
                _currentSkillCooldown = 0;
                _isSkillCooldown = true;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                UsingSkillSlot1();
                _currentSkillCooldown = 0;
                _isSkillCooldown = true;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                UsingSkillSlot2();
                _currentSkillCooldown = 0;
                _isSkillCooldown = true;
            }
        }
        else
        {
            _currentSkillCooldown += Time.deltaTime;
            if (_currentSkillCooldown > skillCooldown)
            {
                _isSkillCooldown = false;
            }
        }

        Movements();
        AnimationCheck();
    }

    public virtual void UsingSkillSlot0()
    {
        GameObject skillObject = PoolingManager.Instance.GetFromPool("Skill0", skillPrefabS0, transform.position, Quaternion.identity);
        pAnim.SetTrigger("UseSkill0");
    }
    public virtual void UsingSkillSlot1()
    {
        GameObject skillObject = PoolingManager.Instance.GetFromPool("Skill1", skillPrefabS1, transform.position, Quaternion.identity);
        pAnim.SetTrigger("UseSkill1");
    }
    public virtual void UsingSkillSlot2()
    {
        GameObject skillObject = PoolingManager.Instance.GetFromPool("Skill2", skillPrefabS2, transform.position, Quaternion.identity);
        pAnim.SetTrigger("UseSkill2");
    }


    void AnimationCheck()
    {
        pAnim.SetInteger("Moving", _movementAnim);
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            _movementAnim = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            _movementAnim = -1;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 ||(Input.GetAxisRaw("Vertical") != 1 && Input.GetAxisRaw("Horizontal") == 1))
        {
            _movementAnim = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 || (Input.GetAxisRaw("Vertical") != -1 && Input.GetAxisRaw("Horizontal") == -1))
        {
            _movementAnim = -1;
        }
    }
}
