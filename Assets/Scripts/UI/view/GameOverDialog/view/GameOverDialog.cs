using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UI.GameOverDialog;
using UI.GameOverDialog.vo;

using Internal.Singleton;

namespace UI.GameOverDialog.view
{
    public class GameOverDialog : Singleton<GameOverDialog>
    {
        [SerializeField]
        private TMP_Text meteorKilled;

        [SerializeField]
        private TMP_Text strongEnemyKilled;

        private Action OnResetCallback;

        private void OnEnable()
        {

        }
        public void SetValues(GameOverDialogVO _gameOverDialogVO)
        {
            meteorKilled.text = _gameOverDialogVO.meteorKilled;
            strongEnemyKilled.text = _gameOverDialogVO.strongEnemyKilled;

            if(_gameOverDialogVO.OnResetCallback != null)
                OnResetCallback = _gameOverDialogVO.OnResetCallback;
        }

        public void BtnReset()
        {
            if(OnResetCallback != null)
                OnResetCallback();
        }
    }
}