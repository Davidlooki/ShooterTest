using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers.Enemies;
using UnityEngine;

namespace CMGA.Shooter.ScriptableObjects{
    [CreateAssetMenu(fileName ="EnemyPool", menuName = "Shooter/new Enemy Pool")]
    public class EnemyPool : ScriptableObject
    {
        public List<GameObject> EnemiesPrefabs;

        public GameObject GetRandomEnemyPrefab(){
            var randomEnemyIndex = Random.Range(0, EnemiesPrefabs.Count);
            return EnemiesPrefabs[randomEnemyIndex];
        }
    }
}