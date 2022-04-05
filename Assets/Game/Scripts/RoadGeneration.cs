using UnityEngine;

namespace Game.Scripts
{
    public class RoadGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject roadPrefab;
        private void Start()
        {
          var spawnPos = new Vector3();
            for (var i = 0; i < 10; i++)
            {
                spawnPos.x = 1.614144f;
                spawnPos.y = 3.732934f;
                spawnPos.z += 20f;
                Instantiate(roadPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
