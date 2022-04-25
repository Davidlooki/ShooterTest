using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CMGA.Shooter.Controllers{
    public class CrosshairPlacementController : MonoBehaviour
    {
        public Transform AimNear;
        public Transform AimFar;

        public Image AimNearUIPortrait;
        public Image AimFarUIPortrait;

        public Image AimNearUILandscape;
        public Image AimFarUILandscape;

        private void UpdateCrosshairs(){

            var isPortrait = Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown;

            var aimNearUI = isPortrait ? AimNearUIPortrait : AimNearUILandscape;
            var aimFarUI = isPortrait ? AimFarUIPortrait : AimFarUILandscape;

            aimNearUI.transform.position = Camera.main.WorldToScreenPoint(AimNear.position);

            aimFarUI.transform.position = Camera.main.WorldToScreenPoint(AimFar.position);
        }

        private void Update(){
            UpdateCrosshairs();
        }
    }
}