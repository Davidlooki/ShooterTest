using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace CMGA.Shooter.Utils{
    public class OrientationController : UIBehaviour
    {
        public Image OrientationSensor;
        public List<Canvas> PortraitCanvases;
        public List<Canvas> LandscapeCanvases;

        protected override void Start(){
            base.Start();

            UpdateUI();
        }
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            UpdateUI();
        }

        private void UpdateUI(){
            if(Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown){
                foreach (var canvas in PortraitCanvases)
                {
                    canvas.gameObject.SetActive(true);    
                }

                foreach (var canvas in LandscapeCanvases)
                {
                    canvas.gameObject.SetActive(false);
                }
                
                
            } else if(Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight){
                foreach (var canvas in PortraitCanvases)
                {
                    canvas.gameObject.SetActive(false);
                }

                foreach (var canvas in LandscapeCanvases)
                {
                    canvas.gameObject.SetActive(true);
                }
            }
        }
    }

    
}