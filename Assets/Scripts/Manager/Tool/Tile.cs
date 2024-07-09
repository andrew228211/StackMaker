using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AT_Tool
{

    public class Tile : MonoBehaviour
    {
        public string tileName;
        [SerializeField] protected SpriteRenderer _renderer;
        [SerializeField] private GameObject _highlight;
        [SerializeField] private TextMeshProUGUI _txtId;
        [SerializeField] private Color _baseColor, _offsetColor;
        public Type type;
        public void Init(int x, int y)
        {
            var isOffset = (x + y) % 2 == 1;
            _renderer.color = isOffset ? _offsetColor : _baseColor;
            type = Type.None;
        }
        public void SetTextId(string _txtId)
        {
            this._txtId.text = _txtId;
        }
        private void OnMouseEnter()
        {
            _highlight.SetActive(true);
        }
        private void OnMouseExit()
        {
            _highlight.SetActive(false);
        }
    }
}