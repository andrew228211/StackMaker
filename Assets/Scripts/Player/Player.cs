using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [Header("Components")]
    public Rigidbody rb;
    public Transform tfrmPlayer;
    public Animator animator;
    public EPlayerDirection dir;
    [SerializeField]private bool _isMoving; //Kiem tra xem co dang di chuyen hay khong
    [SerializeField] private bool _isStuck; // Kiem tra xem het block hay chua
    [Header("Attribute")]
    public PlayerCollision playerCollision;
    public PlayerInput playerInput;
    public HandleImageBlock handleImageBlock;
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
    public void InitAttribute()
    {
        IsMoving = false;
        rb.velocity = Vector3.zero;
    }
}
