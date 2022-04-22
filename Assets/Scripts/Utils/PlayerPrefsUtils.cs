using System;
using UnityEngine;

using Persistent;

namespace Utils
{
    public static class PlayerPrefsUtils 
    {
        private static readonly string playerName = "playerName";
        private static readonly string playerMaxKill = "playerMaxKill";

        public static PlayerData LoadDataFromPlayerPrefs()
        {
            PlayerData playerData = new PlayerData();
            playerData.myName = GetName();
            playerData.playerMaxKill = GetMaxKill();

            return playerData;
        }

        public static void SaveData(PlayerData _playerData)
        {
            if(GetName() != "") 
                PlayerPrefs.SetString(playerName, _playerData.myName);
            if(GetMaxKill() != -1)
            {
                if(GetMaxKill() < _playerData.playerMaxKill)
                    PlayerPrefs.SetInt(playerName, _playerData.playerMaxKill);
            }
        }

        private static string GetName()
        {
            if (!PlayerPrefs.HasKey(playerName))
            {
                PlayerPrefs.SetString(playerName, "Player");
            }
            return PlayerPrefs.GetString(playerName);
        }

        private static int GetMaxKill()
        {
            if (!PlayerPrefs.HasKey(playerMaxKill))
            {
                PlayerPrefs.SetInt(playerMaxKill, 0);
            }
            return PlayerPrefs.GetInt(playerMaxKill);;
        }
    }
}