using System;
using System.Collections;

namespace UI.GameOverDialog.vo
{
    public class GameOverDialogVO
    {
        public string meteorKilled;
        public string strongEnemyKilled;

        public Action OnResetCallback;

        public GameOverDialogVO(string _meteorKilled, string _strongEnemyKilled, Action _onResetCallback = null)
        { 
            meteorKilled = _meteorKilled;
            strongEnemyKilled = _strongEnemyKilled;
            OnResetCallback = _onResetCallback;
        }
    }
}
