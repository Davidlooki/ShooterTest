using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CMGA.Shooter.Utils{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        public TextMeshProUGUI ScoreLandscape;
        public TextMeshProUGUI ScorePortrait;
        private void Start(){
            Instance = this;
        }
        public void GoToGameplayScene(){
            SceneManager.LoadScene(Scenes.GAMEPLAY_SCENE);
        }

        public void GoToTitleScene(){
            SceneManager.LoadScene(Scenes.TITLESCREEN_SCENE);
        }

        public void OpenGithubRepoLink(){
            Application.OpenURL("https://github.com/CaioMGA/ShooterTest/tree/test-CaioMGA");
        }

        public void UpdateScoreUI(int score){
            // TODO: Separate Portrait and Landscape UIs
            ScoreLandscape.text = score.ToString();
            ScorePortrait.text = score.ToString();
        }
    }
}