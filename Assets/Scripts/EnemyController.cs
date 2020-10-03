using UnityEngine;


namespace Player {
    public class EnemyController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().KillPlayer();
            }
        }
    }
}
