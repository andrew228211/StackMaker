using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Canvas_InGame : UICanvas
{
    [SerializeField] private TextMeshProUGUI _txtBlock;
    public override void Setup()
    {
        base.Setup();
        UpdateBlock(1);
        GameManager.Instance.isPlay = true;
    }
    public void ResetBlock()
    {
        DataManager.Instance.Block = 0;
        _txtBlock.text = "0";
    }
    public void UpdateBlock(int _block)
    {
        DataManager.Instance.Block += _block;
        _txtBlock.text = DataManager.Instance.Block.ToString();
    }
    public void SettingsButton()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
        GameManager.Instance.isPlay = true;
    }
    public void HomeButton()
    {
        UIManager.Instance.OpenUI<Canvas_Home>();
        GameManager.Instance.isPlay = false;
    }
}