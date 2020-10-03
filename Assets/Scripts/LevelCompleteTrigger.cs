using UnityEngine;

namespace Triggers
{
    public class LevelCompleteTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            Debug.Log("Level complete");
        }
    }
}
