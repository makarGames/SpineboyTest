using System;
using ScriptableObjects.Classes;
using Spine.Unity;
using UnityEngine;

namespace PlayerLogic
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private PlayerConfiguration _playerConfiguration;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private MeshRenderer _playerRenderer;
        [SerializeField] private PlayerAnimator _playerAnimator;

        [SerializeField] [SpineBone(dataField: "skeletonAnimation")]
        private string _crosshairBoneName;

        public PlayerConfiguration PlayerConfiguration => _playerConfiguration;
        public Transform PlayerTransform => _playerTransform;
        public MeshRenderer PlayerRenderer => _playerRenderer;
        public PlayerAnimator PlayerAnimator => _playerAnimator;
        public string CrosshairBoneName => _crosshairBoneName;
        public float Height => _playerRenderer.bounds.size.y;
    }
}