using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObject : MonoBehaviour
{
    [SerializeField]private int _id;
    public bool check;
    public int GetId()
    {
        return _id;
    }

}
