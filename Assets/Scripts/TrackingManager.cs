using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARPlaneManager))]
public class TrackingManager : MonoBehaviour
{
    private ARPlaneManager planeManager;

    private ARTrackedImageManager trackedImageManager;

    private UIDocument scanUI;
    private VisualElement scanRoot;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void Start()
    {
        //Disable Plane Detection in the beginning
        planeManager.enabled = false;
        planeManager.SetTrackablesActive(false);

        //Enable Image Tracking and Scan UI in the beginning
        trackedImageManager.enabled = true;
        trackedImageManager.SetTrackablesActive(true);
        scanUI = GameObject.Find("ScanUI").GetComponent<UIDocument>();
        scanRoot = scanUI.rootVisualElement.Q<VisualElement>("ScanRoot");
        scanRoot.style.display = DisplayStyle.Flex;
        VisualElement scanDisplay = scanRoot.Q<VisualElement>("ScanAdvice");
        scanDisplay.style.display = DisplayStyle.Flex;
        Button closeButton = scanRoot.Q<Button>("CloseButton");
        closeButton.clicked += () => loadMenuScene();
    }

    private void loadMenuScene() {
        SceneManager.LoadScene("StartScene");
    }
}
