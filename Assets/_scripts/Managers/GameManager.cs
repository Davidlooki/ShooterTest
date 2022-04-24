using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers;
using UnityEngine;
namespace CMGA.Shooter.Managers{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public float GameSpeed = 10;

        private void Start(){
            if(Instance != null) {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            InvokeRepeating(nameof(SpawnEnemy), 1f, 1f);
        }

        private void SpawnEnemy(){
            EnemySpawner.Instance.Spawn();
        }

        
    }
}