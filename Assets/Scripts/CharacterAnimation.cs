using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public static CharacterAnimation Instance;
    [SerializeField] public Animator animator;
    private static readonly int İsMove = Animator.StringToHash("isMove");
    private static readonly int İsWin = Animator.StringToHash("isWin");

    private void Awake()
    {
        Instance = this;
    }

    public void RunAnimation()
    {
        if (GameManager.IsMove)
            animator.SetBool(İsMove,true);

    }
    public void WinAnimation()
    {
        animator.SetBool(İsWin,true);
    }


}
