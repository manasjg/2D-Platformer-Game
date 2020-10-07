using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    public class KeyController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                collision.GetComponent<PlayerController>().PickupKey();
                Destroy(this.gameObject);
            }
               
        }
    }
}
