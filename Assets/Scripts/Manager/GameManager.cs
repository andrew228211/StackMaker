using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameState gameState;
    public bool isPlay;
    public bool isWin;
    public static void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.Home:
                UIManager.Instance.OpenUI<Canvas_Home>();
                break;
            case GameState.InGame:
                UIManager.Instance.OpenUI<Canvas_InGame>();
                break;
            case GameState.WinGame:
                UIManager.Instance.OpenUI<Canvas_WinGame>();
                break;
            case GameState.Setting:
                UIManager.Instance.OpenUI<Canvas_Setting>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    public static bool IsState(GameState state) => gameState == state;
    private void Start()
    {
        Onit();
        ChangeState(GameState.Home);
    }
    private static void Onit()
    {
        LevelManager.Instance.Onit();
    }
}
public enum GameState
{
  None=0,
  Home=1,
  InGame=2,
  WinGame=3,
  Setting=5,
}
