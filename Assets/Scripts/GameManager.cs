using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [SerializeField]
    GameObject GOPanel;
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
    }

   public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }

    public void SetGameOverPanel ()
    {
        GOPanel.SetActive(true);
    }
}
