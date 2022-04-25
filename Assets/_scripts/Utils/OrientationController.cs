using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace CMGA.Shooter.Utils{
    public class OrientationController : UIBehaviour
    {
        public Image OrientationSensor;
        public Canvas PortraitCanvas;
        public Canvas LandscapeCanvas;

        protected override void Start(){
            base.Start();

            UpdateUI();
        }
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            Debug.Log("Mudou");

            UpdateUI();
        }

        private void UpdateUI(){
            if(Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown){
                PortraitCanvas.gameObject.SetActive(true);
                LandscapeCanvas.gameObject.SetActive(false);
            } else if(Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight){
                PortraitCanvas.gameObject.SetActive(false);
                LandscapeCanvas.gameObject.SetActive(true);
            }
        }
    }

    
}