using System;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(Camera))]
    public class CameraHolder : MonoBehaviour
    {
        public static Camera MainCamera { get; private set; }
        public static Vector2 ScreenBounds { get; private set; }

        private void Awake()
        {
            var minX = MainCamera.ViewportToWorldPoint(Vector3.zero).x;
            var maxX = MainCamera.ViewportToWorldPoint(Vector3.right).x;

            ScreenBounds = new Vector2(minX, maxX);
        }

        private void OnValidate()
        {
            MainCamera = GetComponent<Camera>();
        }
    }
}