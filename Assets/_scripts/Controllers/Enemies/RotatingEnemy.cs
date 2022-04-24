using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CMGA.Shooter.Controllers.Enemies{
    public class RotatingEnemy : Enemy
    {

        private void Start(){
            Spin();
        }
        private void Spin(){
            LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360, 25f)
            .setLoopClamp();
        }
    }
}