using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument startUIDocument;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement startRoot = startUIDocument.rootVisualElement.Q<VisualElement>("MenuContainer");
        Button scanStatueButton = startRoot.Q<Button>("ScanStatue");
        scanStatueButton.clicked += () => loadPortalScene();

        Button mapButton = startRoot.Q<Button>("Map");
        mapButton.clicked += () => loadMapScene();
    }

    private void loadPortalScene() {
        SceneManager.LoadScene("PortalScene");
    }

    private void loadMapScene() {
        SceneManager.LoadScene("Location-basedGame");
    }
}
