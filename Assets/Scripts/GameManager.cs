using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [SerializeField]
    GameObject GOPanel;
    [SerializeField]
    Button restartButton;
    [SerializeField]
    int lives;
    [SerializeField]
    GameObject[] Hearts;

    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        restartButton.onClick.AddListener(RestartScene);
    }

   void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }


    public void ReduceLives()
    {
        lives--;
       
        if (lives == 0)
        {
            SetGameOverPanel();
        }
        else
        {
            Hearts[lives].SetActive(false);
        }
    }
    public void SetGameOverPanel ()
    {
        GOPanel.SetActive(true);
    }
}
