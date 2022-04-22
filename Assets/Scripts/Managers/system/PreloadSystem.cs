using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;

using Internal.Singleton;

using Managers;
using Managers.controllers;

using Utils;

public class PreloadSystem : Singleton<PreloadSystem>
{
    private bool preloadComplete = false;

    private void Awake()
    {
        GameManager.Instance.StateType = GameStateType.PRELOAD;

        UIManager.Instance.SetUIByGameState(GameStateType.PRELOAD);

        LoadPlayerData();

        PoolManager.Instance.PreparePoolObjects();

        preloadComplete = true;
    }
    
    private void Start()
    {
        if(preloadComplete)
            GameManager.Instance.Init();
    }

    private void LoadPlayerData()
    {
        var _data = PlayerPrefsUtils.LoadDataFromPlayerPrefs();
        Debug.Log(_data.myName);
    }
}