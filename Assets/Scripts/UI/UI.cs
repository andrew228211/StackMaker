using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : Singleton<UI>
{
    private void Start()
    {
        DataManager.Instance.Block = 0;
    }
    [Header("Home")]
    [SerializeField] private GameObject _panelHome;
    private void InGame()
    {
        _panelHome.SetActive(false);
    }
    private void Home()
    {
        _panelHome.SetActive(true);
    }
    [Header("In Game")]
    [SerializeField] private TextMeshProUGUI txtBlock;
    public void UpdateBlock()
    {
        DataManager.Instance.Block += 1;
        txtBlock.text += DataManager.Instance.Block;

    }
    [Header("Win Game")]
    [SerializeField] private GameObject _panelWin;
    private void PopupWin()
    {
        PoolDataObject.instance.TurnOffAllObject();
    }
    private void Replay()
    {
        
    }
    private void NextLevel()
    {
        DataManager.Instance.CurrentLevel += 1;
        LevelManager.Instance.OnLoadLevel(DataManager.Instance.CurrentLevel);
    }

}
