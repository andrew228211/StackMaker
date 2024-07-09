using AT_InGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour,IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlayBtnClick();
    }
}
