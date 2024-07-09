using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform _target;
    [SerializeField]private Vector3 _offset;
    [SerializeField]private float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }
        transform.position = _target.transform.position + _offset;
    }
    public void SetTarget(Transform _target)
    {
        this._target = _target;
        //_offset = transform.position - _target.transform.position;
    }
}
