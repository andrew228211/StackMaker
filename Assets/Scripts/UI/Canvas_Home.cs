using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
public class Canvas_Home : UICanvas
{
    [SerializeField] private TextMeshProUGUI _txtLevel;
    [SerializeField] private HandMove _handMove;
    public override void Setup()
    {
        base.Setup();
        _txtLevel.text = "Level "+ DataManager.Instance.CurrentLevel.ToString();
        //if(DataManager.Instance.CurrentLevel == 0)
        //{
        //    _handMove.gameObject.SetActive(true);
        //}
        //else
        //{
        //    _handMove.gameObject.SetActive(false);
        //}
    }
    public void TouchToPlayButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<Canvas_InGame>();
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this); ;
    }
}
