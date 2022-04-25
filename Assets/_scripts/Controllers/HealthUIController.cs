using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CMGA.Shooter.Controllers{
    public class HealthUIController : MonoBehaviour
    {
        public Image HealthBarLandscape;
        public Image HealthBarPortrait;
        public void UpdateDisplay(float maxHp, float curHp){
            HealthBarLandscape.fillAmount = curHp/maxHp;
            HealthBarPortrait.fillAmount = curHp/maxHp;
        }
    }
}