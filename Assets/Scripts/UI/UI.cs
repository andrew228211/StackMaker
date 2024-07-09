using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : Singleton<UI>
{
    
    private void Start()
    {
        ResetTextBlock();
    }
    [Header("Home")]
    [SerializeField] private GameObject _panelHome;
    [SerializeField] private TextMeshProUGUI _txtLevel;
    public void InGame()
    {
        _panelHome.SetActive(false);
        _panelInGame.SetActive(true);
        GameManager.Instance.isPlay = true;
    }
    public void Home()
    {
        _panelInGame.SetActive(false );
        _panelHome.SetActive(true);
        GameManager.Instance.isPlay = false;
    }
    [Header("In Game")]
    [SerializeField] private GameObject _panelInGame;
    [SerializeField] private TextMeshProUGUI _txtBlock;
    public void UpdateBlock(int _block)
    {
        DataManager.Instance.Block += _block;
        _txtBlock.text = DataManager.Instance.Block.ToString();
    }
    public void ResetTextBlock()
    {
        DataManager.Instance.Block = 1;
        _txtBlock.text = DataManager.Instance.Block.ToString();
    }
    [Header("Win Game")]
    [SerializeField] private GameObject _panelWin;
    public bool isWin;
    public void OnPopupWin()
    {
        PoolDataObject.instance.TurnOffAllObject();
        Player.Instance.handleImageBlock.ResetImage();
        GameManager.Instance.isPlay = false;
        _panelWin.SetActive(true );
    }
    private void OffPopupWin()
    {
        GameManager.Instance.isPlay = true;
        _panelWin.SetActive(false);
        isWin = false;
        ResetTextBlock();
        Player.Instance.InitAttribute();
    }
    public void Replay()
    {
        _txtLevel.text = DataManager.Instance.CurrentLevel.ToString();
        LevelManager.Instance.OnLoadLevel(DataManager.Instance.CurrentLevel);
        OffPopupWin();
    }
    public void NextLevel()
    {
        DataManager.Instance.CurrentLevel += 1;
        LevelManager.Instance.OnLoadLevel(DataManager.Instance.CurrentLevel);
        _txtLevel.text=DataManager.Instance.CurrentLevel.ToString();
        OffPopupWin();
    }

}
