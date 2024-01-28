using System;
using UnityEngine;

namespace ScriptableObjects.Classes
{
    [Serializable]
    [CreateAssetMenu(menuName = "MyData/PlayerSettings")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}