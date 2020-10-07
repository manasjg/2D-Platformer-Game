using UnityEngine;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private BoxCollider2D StandingCollider, SittingCollider;
        [SerializeField]
        private float speedX,jumpForce;
        [SerializeField]
        private ScoreController scoreController;
        bool resetCollider = false;
        bool jumpFlag = false;
        bool isGrounded = false;
        Rigidbody2D rb2d;

        bool isAlive = true;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            if (resetCollider)
            {
                if (!SittingCollider.enabled)
                {
                    SittingCollider.enabled = true;
                    StandingCollider.enabled = false;
                }
                else
                {
                    SittingCollider.enabled = false;
                    StandingCollider.enabled = true;
                }
                resetCollider = false;
            }
            if (jumpFlag)
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                jumpFlag = false;
            }
        }

        void Update()
        {
            if (isAlive)
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                HandlePlayerAnimation(horizontal, vertical);
                HandlePlayerMovement(horizontal, vertical);
            }
        }

        void HandlePlayerMovement(float horizontal,float vertical)
        {
            transform.position += new Vector3(horizontal * speedX * Time.deltaTime, 0,0);
            if (vertical > 0 && isGrounded)
            {
                isGrounded = false;
                jumpFlag = true;
            }

        }

            
        void HandlePlayerAnimation(float horizontal,float vertical)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector3 scale = transform.localScale;

            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                animator.SetBool("Crouch", false);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                animator.SetBool("Crouch", false);
               
            }
            transform.localScale = scale;

            if (vertical > 0)
            {
                animator.SetBool("Jump", true);
            }
            if (isGrounded)
            {
                animator.SetBool("Jump", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", true);
                resetCollider = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", false);
                resetCollider = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        public void PickupKey()
        {
            scoreController.IncrementScore(10);
        }
        public void KillPlayer()
        {
            animator.SetBool("Crouch", false);
            animator.SetBool("Jump", false);
            animator.SetTrigger("Death");
            isAlive = false;
        }
        public void SetGameOver()
        {
            StandingCollider.enabled = false;
            SittingCollider.enabled = false;
            GameManager.GM.SetGameOverPanel();
        }
    }
}
