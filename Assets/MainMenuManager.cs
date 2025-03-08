using UnityEngine;
using UnityEngine.UIElements;
public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UIDocument uiDocument;

    private void Start()
    {
        // Assuming you have a way to get the UIDocument reference
        uiDocument = GetComponent<UIDocument>();

        // Access an element by name
        Label myLabel = uiDocument.rootVisualElement.Q<Label>("MyLabelName");
        if (myLabel != null)
        {
            myLabel.text = "New Text";
        }
    }
}
