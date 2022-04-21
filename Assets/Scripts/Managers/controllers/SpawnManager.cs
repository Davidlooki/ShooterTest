using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Internal.Singleton;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    private string tagSpawnPoints = "Respawn";

    [SerializeField]
    private GameObject entitiesParent;

    internal bool isReady = false;
    internal List<GameObject> spawnPoints;
    
    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(tagSpawnPoints).ToList();
        isReady = true;
    }

    public void CreateAsset(GameObject _asset)
    {
        //TODO - ON PollManager enable that object
        GameObject _instance = Instantiate(_asset, SelectSpawn());
        _instance.transform.SetParent(entitiesParent.transform);
    }
    public Transform SelectSpawn()
    {
        return spawnPoints[RandomIndex].transform;
    }

    private int RandomIndex
    {
        get
        {
            return Random.Range(0, (spawnPoints.Count - 1));
        }
    }
}
