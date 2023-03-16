using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Examples;
using Mapbox.Utils;

public class EventPointer : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 50f;
    [SerializeField]
    private float amplitude = 2.0f;
    [SerializeField]
    private float frequency = 0.5f;

    LocationStatus playerLocation;

    public Vector2d eventPos;
    public int eventID;

    EventManager eventManager;

    MapPanelUIManager mapPanelUIManager;

    // Start is called before the first frame update
    void Start()
    {
        mapPanelUIManager = GameObject.Find("PanelAdvice").GetComponent<MapPanelUIManager>();
        eventManager = GameObject.Find("-EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    void FloatAndRotatePointer() 
    {
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime*Mathf.PI*frequency)*amplitude) + 7.5f, transform.position.z);
    }

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("PanelAdvice").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);

        if (distance < eventManager.maxDistance) 
        {
            mapPanelUIManager.displayStartEventPanel(eventID);
        } 
        else
        {
            mapPanelUIManager.displayUserNotInRangePanel();
        }        
    }
}
