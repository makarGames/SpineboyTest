using System;
using UnityEngine;

namespace ScriptableObjects.Classes
{
    [Serializable]
    [CreateAssetMenu(menuName = "MyData/PlayerSettings")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField] private float _movementInertia;
        [SerializeField] private float _movementSpeedThreshold;

        [SerializeField] private float _cursorDistanceThreshold;

        public float MovementInertia => _movementInertia;
        public float MovementSpeedThreshold => _movementSpeedThreshold;
        public float CursorDistanceThreshold => _cursorDistanceThreshold;
    }
}