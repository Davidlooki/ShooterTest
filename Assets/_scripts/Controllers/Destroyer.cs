using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CMGA.Shooter.Controllers{
    public class Destroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other){
            Destroy(other.gameObject);
        }

        private void OnTriggerEnter(Collider other){
            Destroy(other.gameObject);
        }
    }
}