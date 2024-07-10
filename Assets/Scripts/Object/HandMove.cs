using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    private Tween _handTween;
   public void MoveHandTutorial()
   {
        _handTween = transform.DOMoveX(8, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _handTween = transform.DOMoveX(-8, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                MoveHandTutorial();
            });
        });
   }
    private void OnEnable()
    {
        MoveHandTutorial();
    }
    private void OnDisable()
    {
        if (_handTween != null)
        {
            _handTween.Kill();
        }
    }
}
