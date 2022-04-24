using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers;
using CMGA.Shooter.Utils;
using UnityEngine;
namespace CMGA.Shooter.Managers{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public float GameSpeed = 10;
        public float PlayerDamage = 1f;
        public float InvincibilityDuration = 3f;

        private void Start(){
            Instance = this;

            InvokeRepeating(nameof(SpawnEnemy), 1f, 1f);
        }

        private void SpawnEnemy(){
            EnemySpawner.Instance.Spawn();
        }

        public void GameOver(){
            CancelInvoke(nameof(SpawnEnemy));
            UIController.Instance.GoToTitleScene();
        }

        
    }
}