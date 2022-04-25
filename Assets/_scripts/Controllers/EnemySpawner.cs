using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers.Enemies;
using CMGA.Shooter.ScriptableObjects;
using UnityEngine;
namespace CMGA.Shooter.Controllers{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance;
        public GameObject SimpleEnemyPrefab;
        public EnemyPool MovingEnemyPool;
        public float SpawnPositionZ = -20f;
        private const float ENEMY_TYPES = 2f;

        private void Awake(){
            Instance = this;
        }
        public void Spawn(){
            var lottery = Random.Range(0f, ENEMY_TYPES);

            if(lottery < 1){
                var randomX = Random.Range(-2, 3);
                var randomY = Random.Range(-2, 3);
                Instantiate(SimpleEnemyPrefab, new Vector3(randomX, randomY, SpawnPositionZ), Quaternion.identity);
            } else {
                // moving enemies
                var enemyPrefab = MovingEnemyPool.GetRandomEnemyPrefab();
                var randomRotation = Random.Range(0f, 180f);
                var initialRotation = Quaternion.Euler(0, 0, randomRotation);
                Instantiate(enemyPrefab, new Vector3(0, 0, SpawnPositionZ), initialRotation);
            }
        }
    }
}