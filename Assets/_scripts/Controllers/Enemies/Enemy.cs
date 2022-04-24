using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Managers;
using UnityEngine;
namespace CMGA.Shooter.Controllers.Enemies{
    public class Enemy : MonoBehaviour
    {  
        public float BaseDamage = 1f;
        private HealthController _health;
        public void MoveTowardsCamera(){
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward * -10f, GameManager.Instance.GameSpeed * Time.deltaTime);
        }

        private void Update(){
            MoveTowardsCamera();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Bullet")){
                _health.TakeDamage(GameManager.Instance.PlayerDamage);
            }
        }
    }
}