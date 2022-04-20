using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.InGameScreen;
using Internal.Singleton;

namespace Managers.controllers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private InGameScreen inGameScreen;

        public InGameScreen InGame
        {
            get
            {
                if (inGameScreen)
                    return inGameScreen;
                else
                    throw new Exception("In Game Screen not found.");
            }
        }
    }
}