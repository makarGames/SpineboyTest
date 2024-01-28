using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class PlayerInput : MonoBehaviour
    {
        public static Vector3 CursorPosition { get; private set; }
        
        private void Update()
        {
            CursorPosition = CameraHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}