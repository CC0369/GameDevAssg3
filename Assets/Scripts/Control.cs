using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoader : MonoBehaviour
{
    public Button levelOneButton;

    void Start()
    {
        levelOneButton.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}