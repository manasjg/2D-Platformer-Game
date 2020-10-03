using UnityEngine;

namespace Triggers
{
    public class GameOverTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                Debug.Log("Game Over");
        }
    }
}
