using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CMGA.Shooter.Controllers{
    public class CrosshairPlacementController : MonoBehaviour
    {
        public Transform AimNear;
        public Transform AimFar;

        public Image AimNearUI;
        public Image AimFarUI;

        private void UpdateCrosshairs(){
            AimNearUI.transform.position = Camera.main.WorldToScreenPoint(AimNear.position);

            AimFarUI.transform.position = Camera.main.WorldToScreenPoint(AimFar.position);
        }

        private void Update(){
            UpdateCrosshairs();
        }
    }
}