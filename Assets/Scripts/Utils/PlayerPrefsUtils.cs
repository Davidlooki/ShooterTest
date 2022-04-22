using System;
using UnityEngine;

using Persistent;

namespace Utils
{
    public class PlayerPrefsUtils 
    {
        private readonly string playerName = "playerName";
        private readonly string playerMaxKill = "playerMaxKill";

        public PlayerData LoadDataFromPlayerPrefs()
        {
            PlayerData playerData = new PlayerData();
            playerData.myName = GetName();
            playerData.playerMaxKill = GetMaxKill();

            return playerData;
        }

        public void SaveData(PlayerData _playerData)
        {
            if(GetName() != "") 
                PlayerPrefs.SetString(playerName, _playerData.myName);
            if(GetMaxKill() != -1)
            {
                if(GetMaxKill() < _playerData.playerMaxKill)
                    PlayerPrefs.SetInt(playerName, _playerData.playerMaxKill);
            }
        }

        private string GetName()
        {
            if (PlayerPrefs.HasKey(playerName))
            {
                return PlayerPrefs.GetString(playerName);
            }
            return "";
        }

        private int GetMaxKill()
        {
            if (PlayerPrefs.HasKey(playerMaxKill))
            {
                return PlayerPrefs.GetInt(playerMaxKill);
            }
            return -1;
        }
    }
}