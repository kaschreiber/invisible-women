using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField]
    private GameObject PlaceablePrefab;

    [SerializeField]
    private GameObject ARCamera;

    private ARPlaneManager planeManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    [SerializeField]
    private UIDocument uIDocument;
    private VisualElement planeDisplay;
    private VisualElement footerDisplay;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        planeDisplay = uIDocument.rootVisualElement.Q<VisualElement>("PlaneAdvice");
        footerDisplay = uIDocument.rootVisualElement.Q<VisualElement>("FooterAdvice");
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = s_Hits[0].pose;

            Vector3 cameraPosition = ARCamera.transform.position;
            hitPos.position.y += 1.1f;
            cameraPosition.y = hitPos.position.y;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(PlaceablePrefab, hitPos.position, hitPos.rotation);
                spawnedObject.transform.LookAt(cameraPosition, spawnedObject.transform.up);
                spawnedObject.transform.Rotate(new Vector3(0, 1, 0), 180);
                planeManager.enabled = false;
                planeManager.SetTrackablesActive(false);
                planeDisplay.style.display = DisplayStyle.None;
                footerDisplay.style.display = DisplayStyle.Flex;
                Label footerText = footerDisplay.Q<Label>("FooterText");
                footerText.text = "Go through the door to get more information about her.";
            }
            // else
            // {
            //     spawnedObject.transform.position = hitPos.position;
            //     spawnedObject.transform.rotation = hitPos.rotation;
            // }
            // spawnedObject.transform.LookAt(cameraPosition, spawnedObject.transform.up);
            // spawnedObject.transform.Rotate(new Vector3(0, 1, 0), 180);
        }
    }
}
