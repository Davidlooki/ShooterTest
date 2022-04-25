using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers;
using CMGA.Shooter.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace CMGA.Shooter.Managers{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public float GameSpeed = 10;
        public float PlayerDamage = 1f;
        public int PlayerScore = 0;
        public int EnemyReward = 100;
        public GameOverScreen GameOverScreen;
        public float InvincibilityDuration = 3f;
        public UnityEvent<int> OnPlayerScore;

        private void Start(){
            Instance = this;

            InvokeRepeating(nameof(SpawnEnemy), 1f, 1f);
        }

        private void SpawnEnemy(){
            EnemySpawner.Instance.Spawn();
        }

        public void GameOver(){
            var bestScore = PlayerPrefs.GetInt("BEST_SCORE");
            if(PlayerScore > bestScore){
                bestScore = PlayerScore;
            }

            PlayerPrefs.SetInt("BEST_SCORE", bestScore);
            PlayerPrefs.SetInt("LAST_SCORE", PlayerScore);
            
            GameOverScreen.UpdateInfo();
            GameOverScreen.gameObject.SetActive(true);

        }

        public static void RegisterEnemyKilled(){
            Instance.PlayerScore += Instance.EnemyReward;

            Instance.OnPlayerScore?.Invoke(Instance.PlayerScore);
        }

        public void TryAgain(){
            UIController.Instance.GoToGameplayScene();
        }

        public void GoHome(){
            UIController.Instance.GoToTitleScene();
        }

        
    }
}