using System;
using ScriptableObjects.Classes;
using UnityEngine;

namespace PlayerLogic
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        public PlayerConfiguration PlayerConfiguration => _playerConfiguration;
    }
}