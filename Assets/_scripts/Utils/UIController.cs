using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CMGA.Shooter.Utils{
    public class UIController : MonoBehaviour
    {
        public void GoToGameplayScene(){
            SceneManager.LoadScene(Scenes.GAMEPLAY_SCENE);
        }

        public void OpenGithubRepoLink(){
            Application.OpenURL("https://github.com/CaioMGA/ShooterTest/tree/test-CaioMGA");
        }
    }
}