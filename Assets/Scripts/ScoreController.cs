using UnityEngine;
using TMPro;

namespace Player
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI scoreText;
        int score = 0;

        private void Start()
        {
            RefreshUI();
        }

        public void IncrementScore(int val)
        {
            score += val;
            RefreshUI();
        }

        void RefreshUI()
        {
            scoreText.text = "Score: " + score;
        }
    }
}
