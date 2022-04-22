using System.Security;
using System.Collections.Generic;
using UnityEngine;

using Internal.Singleton;

using Managers.controllers;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private List<GameObject> objectsToPoolList;

    internal List<GameObject> pooledObjectsList;
    private int totalPerPoolObject = 3;
    
    public void PreparePoolObjects()
    {
        pooledObjectsList = new List<GameObject>();
        foreach(GameObject _poolObject in objectsToPoolList)
        {
            for(int _ind = 0; _ind < totalPerPoolObject; _ind++)
            {
               GameObject _obj = Instantiate(_poolObject);
               _obj.SetActive(false);
               pooledObjectsList.Add(_obj);
            }
        }
    }

    public void DisableAllPooledObjects()
    {
        foreach(GameObject pooledObj in pooledObjectsList)
        {
            pooledObj.SetActive(false);
        }
    }

    public GameObject GetPoolObject()
    {
        GameObject _selectedGameObject = pooledObjectsList[RandomIndexInlist];
        _selectedGameObject.SetActive(true);
        return _selectedGameObject;
    }

    public int RandomIndexInlist
    {
        get
        {
            return Random.Range(0 , (pooledObjectsList.Count - 1));
        }
    }
}
