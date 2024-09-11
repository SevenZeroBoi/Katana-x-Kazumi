using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterScript : MainPlayerScripts
{

    private void Start()
    {
        Setup_PlayerSpeed();
        SetUp_Anim();
    }

    private void Update()
    {
        Movements();
        AnimationCheck();

        if (canUsingSkill && (_nowState == playerStates.IDLE || _nowState == playerStates.MOVING))
        {
            if (Input.GetKeyDown(KeyCode.J)) 
            {
                UsingSkill1Test();
                newcooldown = 0;
                canUsingSkill = false;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                UsingSkill2Test();
                newcooldown = 0;
                canUsingSkill = false;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                UsingSkill3Test();
                newcooldown = 0;
                canUsingSkill = false;
            }
        }
        else if (!canUsingSkill)
        {
            canUsingSkill = SkillCooldownCheck();
        }

    }


    #region Character Movements
    public float currentMoveSpeed;
    void Setup_PlayerSpeed()
    {
        currentMoveSpeed = pStats.chracterMoveSpeed;
    }
    void Movements()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.position = transform.position + new Vector3(moveX, moveY).normalized * Time.deltaTime * currentMoveSpeed;

    }

    void ApplySpeedSlowing()
    {

    }
    #endregion

    #region Character Skills
    private playerStates _nowState;
    float newcooldown = 0;
    bool SkillCooldownCheck()
    {
        newcooldown += Time.deltaTime;
        if (newcooldown >= pStats.skillCooldown) return true;
        Debug.Log(newcooldown);
        return false;
    }

    private bool canUsingSkill = true;
    public GameObject attackingtest;
    public virtual void UsingSkill1Test()
    {
        anim.SetTrigger("attack1");
        Instantiate(attackingtest, gameObject.transform.position,Quaternion.identity);
    }
    void UsingSkill3Test()
    {
        anim.SetTrigger("attack2");
    }
    void UsingSkill2Test()
    {
        anim.SetTrigger("attack3");
    }
    #endregion

    #region Animation
    public Animator anim;
    void SetUp_Anim()
    {
        anim = GetComponent<Animator>();
        _nowState = playerStates.IDLE;
    }

    void AnimationCheck()
    {
        if (_nowState == playerStates.IDLE)
        {
            anim.SetInteger("normal", 0);
        }
        else if (_nowState == playerStates.MOVING)
        {
            anim.SetInteger("normal", 1);
        }


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _nowState = playerStates.MOVING;
        }
        else
        {
            _nowState = playerStates.IDLE;
        }
    }
    #endregion


}
