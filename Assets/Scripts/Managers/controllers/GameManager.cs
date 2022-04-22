using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Internal.Singleton;
using Managers.controllers;

using UI.GameOverDialog.vo;

using Entities.views.player;
using Entities.views.meteor;
using Entities.views.enemy;
using Entities.enums;

using Persistent;
using Managers;

public class GameManager : Singleton<GameManager>
{   
    GameStateType gameStateType;
    private int amountMeteorDies = 0;
    private int amountEnemyDies = 0;

    private Player player;
    
    internal PlayerData initialPlayerData;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player != null)
        {
            player.MyName = initialPlayerData.myName;
            player.MaxKill = initialPlayerData.playerMaxKill;
        }
        Enemy.OnNotifyEnemyDie += OnNotifyEnemyDie;
        Meteor.OnNotifyMeteorDie += OnNotifyMeteorDie;
        Player.OnNotifyPlayerDie += OnNotifyPlayerDie;
    }

    // Start is called before the first frame update
    public void Init()
    {
        StateType = GameStateType.TITLE;
        amountEnemyDies = amountEnemyDies = 0;

        UIManager.Instance.SetUIByGameState(StateType);
    }

    public GameStateType StateType
    {
        get { return gameStateType; }
        set { gameStateType = value; }
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

    public void SetDataToPlayer(PlayerData _dataLoaded)
    {
        initialPlayerData = new PlayerData();
        initialPlayerData.myName = _dataLoaded.myName;
        initialPlayerData.playerMaxKill = _dataLoaded.playerMaxKill;
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

    private void OnDestroy() 
    {
        Enemy.OnNotifyEnemyDie -= OnNotifyEnemyDie;
        Meteor.OnNotifyMeteorDie -= OnNotifyMeteorDie;
        Player.OnNotifyPlayerDie -= OnNotifyPlayerDie;
    }
}