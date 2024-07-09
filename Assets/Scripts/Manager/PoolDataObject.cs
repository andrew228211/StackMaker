using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDataObject : MonoBehaviour
{
    public static PoolDataObject instance;
    [System.Serializable]
    public class Pool
    {
        public TypeDataObject name;
        public DataObject prefab;
        public int size;
        public Transform parent;
    }
    public List<Pool> pools;
    public Dictionary<TypeDataObject, Queue<DataObject>> poolDictionary;
    private void Awake()
    {
        instance = this;

        poolDictionary = new Dictionary<TypeDataObject, Queue<DataObject>>();
        foreach (Pool pool in pools)
        {
            Queue<DataObject> objectPool = new Queue<DataObject>();
            for (int i = 0; i < pool.size; i++)
            {
                DataObject obj = Instantiate(pool.prefab,pool.parent);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectPool);
        }
    }
    public DataObject GetObjet(TypeDataObject name)
    {
        DataObject X = null;
        if (poolDictionary.ContainsKey(name))
        {
            int count = poolDictionary[name].Count;
            for (int i = 0; i < count; i++)
            {
                X = poolDictionary[name].Dequeue();
                poolDictionary[name].Enqueue(X);
                if (!X.transform.gameObject.activeSelf)
                {
                    X.transform.gameObject.SetActive(true);
                    return X;
                }
            }
        }
        if (X != null)
        {
            DataObject obj = Instantiate(X, X.transform.parent);
            poolDictionary[name].Enqueue(obj);
            return obj;
        }
        return null;
    }
    public void TurnOffAllObject()
    {
        foreach(var pool in poolDictionary)
        {
            int count=pool.Value.Count;
            for (int i = 0; i < count; i++)
            {
                var obj = pool.Value.Dequeue();
                pool.Value.Enqueue(obj);
                if(pool.Key.Equals(TypeDataObject.h_bridge)|| pool.Key.Equals(TypeDataObject.v_bridge))
                {
                    obj.objChild.gameObject.SetActive(false);
                    obj.check = false;
                }
                else if(pool.Key.Equals(TypeDataObject.purpelDL)||pool.Key.Equals(TypeDataObject.purpelTR)
                    || pool.Key.Equals(TypeDataObject.purpelTL) || pool.Key.Equals(TypeDataObject.purpelDR))
                {
                    obj.objChild.gameObject.SetActive(true);
                }
                obj.gameObject.SetActive(false);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
            }
        }
    }
}
public enum TypeDataObject
{
    player = 1,
    wall = 2,
    purpelTL = 3,
    purpelTR = 4,
    purpelDL = 5,
    purpelDR = 6,
    eatBlock = 7,
    v_bridge = 8,
    h_bridge = 9,
    dinamond = 10,
    win = 11,
}
