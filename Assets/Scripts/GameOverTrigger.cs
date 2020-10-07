using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers
{
    public class GameOverTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                GameManager.GM.SetGameOverPanel();
        }
    }
}
