using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public static CharacterAnimation Instance;
    [SerializeField] public Animator animator;
    private static readonly int İsMove = Animator.StringToHash("isMove");
    private static readonly int İsDead = Animator.StringToHash("isDead");
    private static readonly int İsWin = Animator.StringToHash("isWin");

    private void Awake()
    {
        Instance = this;
    }

    public void RunAnimation()
    {
        if (GameManager.isMove)
            animator.SetBool(İsMove,true);

    }

    private void DeadAnimation()
    {
        animator.SetBool(İsDead,true);
    }

    private void WinAnimation()
    {
        animator.SetBool(İsWin,true);
    }


}
