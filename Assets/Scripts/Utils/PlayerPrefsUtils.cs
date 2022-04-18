using System;
using UnityEngine;

using Persistent;

namespace Utils
{
    public class PlayerPrefsUtils
    {
        private readonly string playerName = "playerName";
        private readonly string playerHighestScore = "playerHighestScore";

        public PlayerData LoadDataFromPlayerPrefs()
        {
            PlayerData playerData = new PlayerData();
            playerData.myName = GetName();
            playerData.highestScore = GetHighestScore();

            return playerData;
        }

        public void SaveData(PlayerData _playerData)
        {
            if(GetName() != "") 
                PlayerPrefs.SetString(playerName, _playerData.myName);
            if(GetHighestScore() != -1)
                PlayerPrefs.SetInt(playerName, _playerData.highestScore);
        }

        private string GetName()
        {
            if (PlayerPrefs.HasKey(playerName))
            {
                return PlayerPrefs.GetString(playerName);
            }
            return "";
        }

        private int GetHighestScore()
        {
            if (PlayerPrefs.HasKey(playerHighestScore))
            {
                return PlayerPrefs.GetInt(playerHighestScore);
            }
            return -1;
        }
    }
}