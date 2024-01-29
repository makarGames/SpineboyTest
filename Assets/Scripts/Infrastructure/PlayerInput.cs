using System;
using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action OnClickUpEvent;
        public static event Action OnClickDownEvent;
        public static Vector3 CursorWorldPosition { get; private set; }

        private void Update()
        {
            CursorWorldPosition = CameraHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(1))
            {
                OnClickDownEvent?.Invoke();
            }
            if (Input.GetMouseButtonUp(1))
            {
                OnClickUpEvent?.Invoke();
            }
        }
    }
}