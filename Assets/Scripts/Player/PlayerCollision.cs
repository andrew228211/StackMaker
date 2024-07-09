using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _posCenter;//Vi tri trung tam ban tia raycast
    private Vector3 _dir;//Huong ban tia Raycast
    [SerializeField]private float _distanceShootRay = 0.8f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision == null)
        {
            return;
        }
        else if (collision.CompareTag("eatAbleBlock"))
        {
            collision.gameObject.SetActive(false);
            Player.Instance.animator.SetInteger("Jump", 1);
            EventDispatcher.Instance.PostEvent(EventID.OnEatBlock);       
        }
        else if (collision.CompareTag("bridge"))
        {
            DataObject bridge = collision.GetComponent<DataObject>();
            if (!bridge.check)
            {
                StartCoroutine(IWaitToOff(bridge));
            }
        }
    }

    IEnumerator IWaitToOff(DataObject bridge)
    {
        yield return new WaitForSeconds(0.064f);
        EventDispatcher.Instance.PostEvent(EventID.OnRemoveBlock);
        bridge.objChild.gameObject.SetActive(true);
        bridge.check = true;
    }
    #region Create Raycast
    public bool HandleCollisionWithWall()
    {
        RaycastHit hit;
        switch (Player.Instance.dir)
        {
            case EPlayerDirection.LEFT:
                _dir = Vector3.left;
                break;
            case EPlayerDirection.RIGHT:
                _dir = Vector3.right;
                break;
            case EPlayerDirection.TOP:
                _dir = Vector3.forward;
                break;
            case EPlayerDirection.DOWN:
                _dir = Vector3.back;
                break;
            default:
                _dir = Vector3.zero;
                break;
        }
        Debug.DrawRay(Player.Instance.tfrmPlayer.position+ Vector3.up, _dir* _distanceShootRay *10f, Color.green);

        if (Physics.Raycast(_posCenter.position, _dir, out hit, _distanceShootRay, _layerMask))
        {          
            Player.Instance.IsMoving = false;
            Player.Instance.rb.velocity = Vector2.zero;
            Player.Instance.animator.SetInteger("Jump", 1);
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}
