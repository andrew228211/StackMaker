using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_WinGame : UICanvas
{

    public override void Setup()
    {
        base.Setup();
        PoolDataObject.instance.TurnOffAllObject();
        Player.Instance.handleImageBlock.ResetImage();
        GameManager.Instance.isPlay = false;
    }
    public void InGameButton()
    {
        UIManager.Instance.OpenUI<Canvas_Home>();
    }
    public void ReplayButton()
    {
        OffCanvas();
        LevelManager.Instance.OnLoadLevel(DataManager.Instance.CurrentLevel);
        UIManager.Instance.OpenUI<Canvas_InGame>().ResetBlock();
    }
    public void NextLevelButton()
    {
        Close(0);
        OffCanvas();
        DataManager.Instance.CurrentLevel += 1;
        LevelManager.Instance.OnLoadLevel(DataManager.Instance.CurrentLevel);
        UIManager.Instance.OpenUI<Canvas_InGame>().ResetBlock();

    }
    private void OffCanvas()
    {
        Close(0);
        GameManager.Instance.isPlay = true;
        GameManager.Instance.isWin = false;
        Player.Instance.InitAttribute();
    }
}
