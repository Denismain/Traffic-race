using UnityEngine;

namespace Game.Scripts
{
    public class RoadDestroy : MonoBehaviour
    {
       
        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.name != "RepeatRoad") return;
            var transform1 = transform;
            transform1.position = new Vector3(1.614144f, 3.732934f, transform1.position.z + 44f);
        }
    }
}
