using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UIDocument uiDocument;
    public string gameTitleText = "RGP Game";
    private int levelSceneIndex = 1;

    private void Start()
    {
        // Assuming you have a way to get the UIDocument reference
        uiDocument = GetComponent<UIDocument>();

        // Access an element by name
        Label myLabel = uiDocument.rootVisualElement.Q<Label>("gameTitle");
        Button playBtn = uiDocument.rootVisualElement.Q<Button>("StartBtn");
        Button settingsBtn = uiDocument.rootVisualElement.Q<Button>("SettingsBtn");
        Button exitBtn = uiDocument.rootVisualElement.Q<Button>("ExitBtn");
        if (myLabel != null)
        {
            myLabel.text = gameTitleText;
        }
        if (playBtn != null)
        {
            playBtn.clicked += playGame;
        }
        if (settingsBtn != null)
        {
            settingsBtn.clicked += SettingsClicked;
        }
        if (exitBtn != null)
        {
            exitBtn.clicked += ExitGame;
        }
    }
    private void playGame()
    {
        Debug.Log("Play game clicked");
        loadLevelScene();
    }
    private void ExitGame()
    {
        Debug.Log("Exit game clicked");
    }

    private void SettingsClicked()
    {
        Debug.Log("Settings clicked");
    }
    private void loadLevelScene()
    {
        SceneManager.LoadScene(levelSceneIndex);
    }
}
