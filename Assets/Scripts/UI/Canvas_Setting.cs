using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Setting : UICanvas
{
    [SerializeField] GameObject[] buttons;

    //Xet trang thai xem ben nao dong mo de bat no
    public void SetState(UICanvas canvas)
    {
        
    }
    public void Home()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_InGame>();
    }

}
