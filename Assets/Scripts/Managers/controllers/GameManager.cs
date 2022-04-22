using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Internal.Singleton;
using Managers.controllers;

using UI.GameOverDialog.vo;

using Entities.views.player;
using Entities.enums;

using Persistent;
using Utils;
using Managers;

public class GameManager : Singleton<GameManager>
{   
    GameStateType gameStateType;
    PlayerData playerData;
    PlayerPrefs playerPrefs;
    private int amountMeteorDies = 0;
    private int amountEnemyDies = 0;

    private Player player;

    private void Awake() 
    {
        PoolManager.Instance.PreparePoolObjects();
    }

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //TODO - CLEAN UI    
    }


    // Start is called before the first frame update
    public void Init()
    {
        StateType = GameStateType.TITLE;
        amountEnemyDies = amountEnemyDies = 0;
    }

    public GameStateType StateType
    {
        get { return gameStateType; }
        private set { gameStateType = value; }
    }

    public void StartGame()
    {
        StateType = GameStateType.INGAME;
        player.StateType = EntityStateType.LIVE;
        player.Init();

        PullObjectInScene();
    }

    public void PullObjectInScene()
    {
        GameObject _pooledObject = PoolManager.Instance.GetPoolObject();
        SpawnManager.Instance.CreateAsset(_pooledObject);
    }

    public void OnNotifyMeteorDie()
    {
        amountMeteorDies++;
        UIManager.Instance.InGame.SetWeakEnemyKills(amountMeteorDies);
        PullObjectInScene();
    }

    public void OnNotifyEnemyDie()
    {
        amountEnemyDies++;
        UIManager.Instance.InGame.SetWeakEnemyKills(amountEnemyDies);
        PullObjectInScene();
    }

    public void OnNotifyPlayerDie()
    {
        StateType = GameStateType.GAMEOVER;
        UIManager.Instance.SetUIByGameState(StateType);
        GameOverDialogVO _gameOverVO = new GameOverDialogVO(amountMeteorDies.ToString(),
                                                            amountEnemyDies.ToString(),
                                                            () => {
                                                                Init(); 
                                                                });
        UIManager.Instance.GameOver.SetValues(_gameOverVO);
    }
}