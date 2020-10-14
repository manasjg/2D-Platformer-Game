using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    Button StartButton;

    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
