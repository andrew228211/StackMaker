using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerCollision _playerCollision;
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _dirMove;
    private Vector3 _input;
    [SerializeField] private float _speed;
    private bool _isCollision;
    private Tween _tweenMove;
    
    private void FixedUpdate()
    {

        if (!_player.IsMoving)
        {
            HandWithInput();
        }
        else
        {
            _isCollision = _playerCollision.HandleCollisionWithWall(); //Them dieu kien win o day de tat no di
        }
        if (_player.IsMoving && !_isCollision)
        {
            _player.rb.velocity = _input * Time.fixedDeltaTime * _speed;
        }
    }
    #region Handle Input
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
                    _player.dir = EPlayerDirection.TOP;
                //    Debug.Log("Top");
                  
                }
                else
                {
                    _input = Vector3.back;
                    _player.dir = EPlayerDirection.DOWN;
                  //  Debug.Log("Down");

                }
            }
            else if (Mathf.Abs(_dirMove.x) < Mathf.Abs(_dirMove.y))
            {
                if (_dirMove.y < 0)
                {
                    _input = Vector3.right;
                    _player.dir = EPlayerDirection.RIGHT;
                  //  Debug.Log("Right");
                }
                else
                {
                    _input = Vector3.left;
                    _player.dir = EPlayerDirection.LEFT;
                 //   Debug.Log("Left");
                }
            }
            _player.animator.SetInteger("Jump", 0);
            _player.IsMoving = true;
        }
    }
    #endregion
}
