using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;
    private bool _isMove => isMove;
    public static bool isMove;
    private bool _isDead => isDead;
    public static bool isDead;

    private void Awake()
    {
        Instance = this;
    }
}
