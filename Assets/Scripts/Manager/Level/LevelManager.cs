using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LevelManager : Singleton<LevelManager>
{
    private string _srcLevel = "Level/Level_";
    [SerializeField] private List<GridData> _listGridData;
    public void Onit()
    {
        DataManager.Instance.CurrentLevel = 1;
        OnLoadLevel(1);
    }

    //Reset ket thuc Game
    public void OnReset()
    {

    }

    //Load level: level bat dau tu 0
    public void OnLoadLevel(int level)
    {
        _srcLevel = "Level/Level_" + level.ToString();
        Map map = FileHandle.LoadToJson<Map>(_srcLevel);
        _listGridData = map.arrToolData;
        _listGridData.RemoveAt(_listGridData.Count - 1);
        foreach (GridData gridData in _listGridData)
        {

            DataObject dataObject = GetObjectById(gridData.id);
            //Debug.Log(dataObject.GetId() + " x " + gridData.id);
            dataObject.transform.localPosition = CovertVector3(gridData.x, dataObject.transform.position.y, gridData.y);
            if (gridData.id == 1)
            {
                AddObject(1, gridData);
            }
        }
    }
    private void AddObject(int id, GridData gridData)
    {
        DataObject dataObject = null;
        if (id == 1)
        {
            dataObject = PoolDataObject.instance.GetObjet(TypeDataObject.eatBlock);
            dataObject.transform.localPosition = CovertVector3(gridData.x, dataObject.transform.position.y, gridData.y);
        }
    }
    private DataObject GetObjectById(int id)
    {
        DataObject dataObj = null;
        switch (id)
        {
            case 1:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.player);
                dataObj.GetComponent<Player>().SetCamFollowPlayer();
                break;
            case 2:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.wall);
                break;
            case 3:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.eatBlock);
                break;
            case 4:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.v_bridge);
                break;
            case 5:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.purpelTL);
                break;
            case 6:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.purpelDR);
                break;
            case 7:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.purpelTR);
                break;
            case 8:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.purpelDL);
                break;
            case 9:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.win);
                break;
            case 10:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.h_bridge);
                break;
            case 11:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.v_bridge);
                break;
            case 12:
                dataObj = PoolDataObject.instance.GetObjet(TypeDataObject.h_bridge);
                break;
            default:
                break;
        }
        return dataObj;
    }
    private Vector3 CovertVector3(int x, float z, int y)
    {
        return new Vector3(y, z, x);
    }
}
