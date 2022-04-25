using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace CMGA.Shooter.Controllers{
    public class GameOverScreen : MonoBehaviour
    {
        public TextMeshProUGUI BestScore;
        public TextMeshProUGUI LastScore;

        public void UpdateInfo()
        {
            BestScore.text = "Best score: " + PlayerPrefs.GetInt("BEST_SCORE").ToString();

            LastScore.text = "last score: " + PlayerPrefs.GetInt("LAST_SCORE").ToString();
        }
    }
}