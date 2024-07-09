using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameState gameState;
    [SerializeField]private CameraFollow _cameraFollow;
    public void SetTargetForCameraFollow(Transform _target)
    {
        _cameraFollow.SetTarget(_target);
    }
    public static void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                UIManager.Instance.OpenUI<UIMainMenu>();
                break;
            case GameState.GamePlay:
                Onit();
                break;
            case GameState.Finish:
                break;
            case GameState.Replay:
                break;
            case GameState.Setting:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    public static bool IsState(GameState state) => gameState == state;
    private void Start()
    {
        ChangeState(GameState.GamePlay);
    }
    private static void Onit()
    {
        LevelManager.Instance.Onit();
    }
}
public enum GameState
{
  None=0,
  MainMenu=1,
  GamePlay=2,
  Finish=3,
  Replay=4,
  Setting=5,
}
