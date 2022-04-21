using UnityEngine;

using Internal.Singleton;

using UI.TitleScreen;
using UI.InGameScreen;
using UI.GameOverDialog.view;

using Managers;

namespace Managers.controllers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private InGameScreen inGameScreen;

        [SerializeField]
        private TitleScreen titleScreen;

        [SerializeField]
        private GameOverDialog gameOverDialog;

        public InGameScreen InGame => inGameScreen;

        public TitleScreen Title => titleScreen;

        public GameOverDialog GameOver => gameOverDialog;

        private void Start()
        {
            SetUIByGameState(GameStateType.TITLE);
        }

        public void SetUIByGameState(GameStateType _gameStateType)
        {
            switch (_gameStateType)
            {
                case (GameStateType.TITLE):
                    Title.gameObject.SetActive(true);
                    GameOver.gameObject.SetActive(false);
                    InGame.gameObject.SetActive(false);
                    break;
                case (GameStateType.INGAME):
                    InGame.gameObject.SetActive(true);
                    Title.gameObject.SetActive(false);
                    GameOver.gameObject.SetActive(false);
                    break;
                case (GameStateType.GAMEOVER):
                    GameOver.gameObject.SetActive(true);
                    Title.gameObject.SetActive(false);
                    InGame.gameObject.SetActive(false);
                    break;
                
            }
        }
    }
}