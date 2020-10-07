using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [SerializeField]
    GameObject GOPanel;
    [SerializeField]
    Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        RestartButton.onClick.AddListener(RestartScene);
    }

   void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }

    public void SetGameOverPanel ()
    {
        GOPanel.SetActive(true);
    }
}
