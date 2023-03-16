using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MapPanelUIManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument panelUI;

    VisualElement panelInRange;
    VisualElement panelNotInRange;

    int tempEvent;

    bool isUIPanelActive;

    [SerializeField]
    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement panelRoot = panelUI.rootVisualElement.Q<VisualElement>("PanelRoot");
        panelInRange = panelRoot.Q<VisualElement>("PanelInRange");
        panelNotInRange = panelRoot.Q<VisualElement>("PanelNotInRange");

        Button scanButton = panelInRange.Q<Button>("ScanStatue");
        scanButton.clicked += () => onScanStatue();
        Button closeButtonInRange = panelInRange.Q<Button>("CloseAdvice");
        closeButtonInRange.clicked += () => CloseButtonClick();
        Button closeButtonNotInRange = panelNotInRange.Q<Button>("CloseAdvice");
        closeButtonNotInRange.clicked += () => CloseButtonClick();
        Button closeMenuButton = panelRoot.Q<Button>("CloseButton");
        closeMenuButton.clicked += () => loadMenuScene();
    }

    public void displayStartEventPanel(int eventID)
    {
        if (!isUIPanelActive)
        { 
            tempEvent = eventID;
            panelInRange.style.display = DisplayStyle.Flex;
            //eventPanelUserInRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void onScanStatue() 
    {
       eventManager.ActivateEvent(tempEvent);
;    }

    public void displayUserNotInRangePanel() {
        if (!isUIPanelActive) 
        {
            panelNotInRange.style.display = DisplayStyle.Flex;
            //eventPanelUserNotInRange.SetActive(true);
            isUIPanelActive = true;
        }
    }

    public void CloseButtonClick() {
        panelInRange.style.display = DisplayStyle.None;
        panelNotInRange.style.display = DisplayStyle.None;
        //eventPanelUserNotInRange.SetActive(false);
        //eventPanelUserInRange.SetActive(false);
        isUIPanelActive = false;
    }

    public void loadMenuScene() {
        Debug.Log("Click Close");
        SceneManager.LoadScene("StartScene");
    }
}
