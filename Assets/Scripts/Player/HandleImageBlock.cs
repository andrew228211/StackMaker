using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleImageBlock : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _image;
    private Vector3 _offset = new Vector3(0, 0.4f, 0);
    [SerializeField]private List<GameObject> _listBlockEated;
    private void OnEnable()
    {
        _listBlockEated = new List<GameObject>();
        EventDispatcher.Instance.RegisterListener(EventID.OnEatBlock, (x) => EatBlock());
        EventDispatcher.Instance.RegisterListener(EventID.OnRemoveBlock, (y) => RemoveBlock());
        EventDispatcher.Instance.RegisterListener(EventID.OnTurnOffAllBlock, (z) => TurnOffAllBlock());
    }
    private void EatBlock()
    {
        GameObject block = ObjectPool.instance.GetObjet("block");
        _image.localPosition += _offset;
        block.transform.parent = _image.transform;
        if(_listBlockEated.Count > 0)
        {
            block.transform.localPosition = _offset * -1 + _listBlockEated.Last().transform.localPosition;
            UI.Instance.UpdateBlock(1);
        }
        else
        {
            block.transform.localPosition = new Vector3(0, -0.3f, 0);
        }
        _listBlockEated.Add(block);
    }
    private void RemoveBlock()
    {
        if (_listBlockEated != null)
        {
            _image.localPosition -= _offset;
            _listBlockEated[_listBlockEated.Count - 1].transform.parent = null;
            _listBlockEated[_listBlockEated.Count - 1].SetActive(false);
            _listBlockEated.RemoveAt(_listBlockEated.Count - 1);
            UI.Instance.UpdateBlock(-1);
        }
    }
    private void TurnOffAllBlock()
    {
        if (_listBlockEated != null)
        {
            for(int i = 0; i < _listBlockEated.Count; i++)
            {
                _listBlockEated[i].SetActive(false);
            }
            _image.localPosition = Vector3.zero;
        }
    }
}
