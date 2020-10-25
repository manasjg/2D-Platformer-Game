using UnityEngine;


namespace Player {
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private float walkSpeed;
        [SerializeField]
        private bool canReverseDirection;

        private void Update()
        {
           
                if (transform.localScale.x < 0)
                {
                    transform.position -= new Vector3(walkSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);
                }
       
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            { 
                collision.gameObject.GetComponent<PlayerController>().KillPlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                if (canReverseDirection)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
            }
        }
    }
}
