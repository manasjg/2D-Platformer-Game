using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    string levelName;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        LevelState state = LevelManager.Instance.GetLevelStatus(levelName);
        switch (state)
        {
            case LevelState.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelState.Completed:
                SceneManager.LoadScene(levelName);
                break;
            case LevelState.Locked:
                Debug.Log(levelName + " is locked");
                break;
        }
        
    }
}
