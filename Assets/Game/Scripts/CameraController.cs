using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform carTransform;
        
        private void Update()
        {
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, position.y, carTransform.position.z - 5f);
            transform1.position = position; 
        }

    }
}
