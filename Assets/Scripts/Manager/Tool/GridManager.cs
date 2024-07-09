using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace AT_Tool
{
    public class GridManager : Singleton<GridManager>
    {
        [SerializeField] private int _width, _height;
        [SerializeField] private Tile _grassTile;
        [SerializeField] private Transform _cam;
        private Dictionary<Vector2, Tile> _tiles;
        public void GenerateGrid()
        {
            _tiles = new Dictionary<Vector2, Tile>();
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var spawnedTile = Instantiate(_grassTile, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.Init(x, y);
                    _tiles[new Vector2(x, y)] = spawnedTile;
                }
            }
            _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        }

    }
}
