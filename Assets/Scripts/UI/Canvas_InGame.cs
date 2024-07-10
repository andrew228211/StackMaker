using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Canvas_InGame : UICanvas
{
    [SerializeField] private TextMeshProUGUI _txtBlock;
    private int _block;
    public override void Setup()
    {
        base.Setup();
        _block = 0;
        UpdateBlock(1);
        GameManager.Instance.isPlay = true;
    }
    public void ResetBlock()
    {
        DataManager.Instance.Block = 0;
        _txtBlock.text = "0";
        _block = 0;
    }
    public void UpdateBlock(int block)
    {
        if (block >0)
        {
            DataManager.Instance.Block += block;
        }
        _block += block;
        _txtBlock.text = _block.ToString();
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