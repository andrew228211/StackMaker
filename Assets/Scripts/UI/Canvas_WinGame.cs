using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas_WinGame : UICanvas
{
    [SerializeField] private TextMeshProUGUI txtScore;
    public override void Setup()
    {
        base.Setup();
        PoolDataObject.instance.TurnOffAllObject();
        Player.Instance.handleImageBlock.ResetImage();
        txtScore.text = DataManager.Instance.Block.ToString();
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
        GameManager.Instance.isWin = false;
        Player.Instance.InitAttribute();
    }
}
