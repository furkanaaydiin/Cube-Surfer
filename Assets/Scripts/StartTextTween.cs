using System;
using UnityEngine;
using DG.Tweening;


namespace Character
{
    public class StartTextTween : MonoBehaviour
    {
        private void Awake()
        {
            StartText();
        }

        private void StartText()
        {
            gameObject.transform.DOScale(Vector3.one * 1.3f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}