using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Managers;
using UnityEngine;

namespace CMGA.Shooter.Controllers{
    public class ShootingModuleController : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other) {
            Debug.Log("Ouch");
            if(other.CompareTag("Enemy")){
                other.gameObject.GetComponent<HealthController>().TakeDamage(GameManager.Instance.PlayerDamage);
            }
        }
    }
}