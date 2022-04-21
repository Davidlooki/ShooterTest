using UnityEngine;

using Internal.Singleton;

using Managers.controllers;

namespace UI.TitleScreen
{
    public class TitleScreen : Singleton<TitleScreen>
    {
        public void BtnStart()
        {
            UIManager.Instance.SetUIByGameState(Managers.GameStateType.INGAME);
        }
    }
}