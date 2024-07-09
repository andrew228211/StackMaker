using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AT_Tool
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            GridManager.Instance.GenerateGrid();
        }
    } 
}
