using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UIElements;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingParis : MonoBehaviour
{

    private ARTrackedImageManager trackedImageManager;
    private ARPlaneManager planeManager;

    [SerializeField]
    private UIDocument uIDocument;

    private VisualElement scanDisplay;
    private VisualElement foundDisplay;
    private VisualElement planeDisplay;
    private Button placeOrder;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        planeManager = GetComponent<ARPlaneManager>();

        scanDisplay = uIDocument.rootVisualElement.Q<VisualElement>("ScanAdvice");
        //scanDisplay.style.display = DisplayStyle.Flex;
        scanDisplay.style.display = DisplayStyle.None;

        foundDisplay = uIDocument.rootVisualElement.Q<VisualElement>("FoundAdvice");
        planeDisplay = uIDocument.rootVisualElement.Q<VisualElement>("PlaneAdvice");

        placeOrder = uIDocument.rootVisualElement.Q<Button>("PlaceDoor");
        placeOrder.clicked += () => enablePlaneDetection();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (!planeManager.enabled) {
            trackedImageManager.enabled = false;
            trackedImageManager.SetTrackablesActive(false);
            scanDisplay.style.display = DisplayStyle.None;
            foundDisplay.style.display = DisplayStyle.Flex;
            placeOrder.style.display = DisplayStyle.Flex;
        }
    }

    private void enablePlaneDetection()
    {
        foundDisplay.style.display = DisplayStyle.None;
        placeOrder.style.display = DisplayStyle.None;
        planeManager.enabled = true;
        planeManager.SetTrackablesActive(true);
        planeDisplay.style.display = DisplayStyle.Flex;
    }
 }
