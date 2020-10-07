﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers
{
    public class LevelCompleteTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
