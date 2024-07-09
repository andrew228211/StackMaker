using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public Transform tfrmPlayer;
    public Animator animator;
    public EPlayerDirection dir;
    [SerializeField]private bool _isMoving; //Kiem tra xem co dang di chuyen hay khong
    [SerializeField] private bool _isStuck; // Kiem tra xem het block hay chua
    public bool IsMoving
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }
    public bool IsStuck
    {
        get { return _isStuck; }
        set { _isStuck = value; }
    }
    public void SetCamFollowPlayer()
    {
        GameManager.Instance.SetTargetForCameraFollow(tfrmPlayer);
        IsMoving = false;
    }
}
