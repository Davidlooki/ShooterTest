using UnityEngine;

using Internal.Singleton;

using UI.TitleScreen;
using UI.InGameScreen;

using Managers;

namespace Managers.controllers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private InGameScreen inGameScreen;
        
        [SerializeField]
        private TitleScreen titleScreen;

        public InGameScreen InGame
        {
            get
            {
                return inGameScreen;
            }
        }

        public TitleScreen Title
        {
            get
            {
                return titleScreen;
            }
        }

        private void Start() 
        {
            SetUI(GameStateType.TITLE);
        }

        public void SetUI(GameStateType _gameStateType)
        {
            switch(_gameStateType)
            {
                case(GameStateType.TITLE):  
                    Title.gameObject.SetActive(true);
                    InGame.gameObject.SetActive(false);
                    break;
                case(GameStateType.INGAME):
                    Title.gameObject.SetActive(false);
                    InGame.gameObject.SetActive(true);
                    break;
            }
        }
    }
}