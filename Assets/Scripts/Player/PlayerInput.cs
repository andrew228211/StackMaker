using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _dirMove;
    private Vector3 _input;
    [SerializeField] private float _speed;
    private bool _isCollision;

    
    private void FixedUpdate()
    {

        if (GameManager.gameState!=GameState.InGame)
        {
            return;
        }
        if (!Player.Instance.IsMoving)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            HandWithInput();
#else
     HandWithInputUseMobile(); 
#endif
        }
        else if(!GameManager.Instance.isWin)
        {
            _isCollision = Player.Instance.playerCollision.HandleCollisionWithWall();
        }
        if (Player.Instance.IsMoving && !_isCollision)
        {
            Player.Instance.rb.velocity = _input * Time.fixedDeltaTime * _speed;
        }
    }
    #region Handle Input In Editor
    private void HandWithInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _endPoint = Input.mousePosition;
            _dirMove = _endPoint - _startPoint;
            if (Mathf.Abs(_dirMove.x) > Mathf.Abs(_dirMove.y))
            {
                if (_dirMove.x > 0)
                {
                    _input = Vector3.forward;
                    Player.Instance.dir = EPlayerDirection.TOP;               
                }
                else
                {
                    _input = Vector3.back;
                    Player.Instance.dir = EPlayerDirection.DOWN;
                }
            }
            else if (Mathf.Abs(_dirMove.x) < Mathf.Abs(_dirMove.y))
            {
                if (_dirMove.y < 0)
                {
                    _input = Vector3.right;
                    Player.Instance.dir = EPlayerDirection.RIGHT;
                }
                else
                {
                    _input = Vector3.left;
                    Player.Instance.dir = EPlayerDirection.LEFT;
                }
            }
            Player.Instance.animator.SetInteger("Jump", 0);
            Player.Instance.IsMoving = true;
            Player.Instance.SetKinematic(false);
        }
    }
    #endregion
    #region Handle Input In Mobile
    private void HandWithInputUseMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                _startPoint = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                _endPoint = touch.position;
                _dirMove = _endPoint - _startPoint;

                if (Mathf.Abs(_dirMove.x) > Mathf.Abs(_dirMove.y))
                {
                    if (_dirMove.x > 0)
                    {
                        _input = Vector3.forward;
                        Player.Instance.dir = EPlayerDirection.TOP;
                    }
                    else
                    {
                        _input = Vector3.back;
                        Player.Instance.dir = EPlayerDirection.DOWN;
                    }
                }
                else if (Mathf.Abs(_dirMove.x) < Mathf.Abs(_dirMove.y))
                {
                    if (_dirMove.y < 0)
                    {
                        _input = Vector3.right;
                        Player.Instance.dir = EPlayerDirection.RIGHT;
                    }
                    else
                    {
                        _input = Vector3.left;
                        Player.Instance.dir = EPlayerDirection.LEFT;
                    }
                }
                Player.Instance.animator.SetInteger("Jump", 0);
                Player.Instance.IsMoving = true;
                Player.Instance.SetKinematic(false);
            }
        }
    }

    #endregion
}
