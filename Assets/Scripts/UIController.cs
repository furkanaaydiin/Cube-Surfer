using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;
using Button = UnityEngine.UI.Button;
using DG.Tweening;

public class UIController : MonoBehaviour
{
   
    [SerializeField] private Button tapToStartButton;

    private void Start()
    {
        tapToStartButton.onClick.AddListener(TapToStart);
    }
    private void TapToStart()
    {
        GameManager.isMove = true;
        tapToStartButton.gameObject.transform.DOScale(Vector3.one * 0f, 1f).SetEase(Ease.Linear).OnComplete( 
            () => Destroy(tapToStartButton.gameObject));
    }
    
}
