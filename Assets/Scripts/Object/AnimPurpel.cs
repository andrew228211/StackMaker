using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPurpel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetInteger("purpel", 0);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetInteger("purpel", 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetInteger("purpel", 1);
        }
    }
}
