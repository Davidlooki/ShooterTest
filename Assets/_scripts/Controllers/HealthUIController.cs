using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CMGA.Shooter.Controllers{
    public class HealthUIController : MonoBehaviour
    {
        public Image HealthBar;
        public void UpdateDisplay(float maxHp, float curHp){
            HealthBar.fillAmount = curHp/maxHp;
        }
    }
}