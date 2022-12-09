using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Method created for some tests using orientation of AR
public class PlaceWhereWatching : MonoBehaviour
{
    ARRaycastManager rayMgr;

    // Start is called before the first frame update
    void Start()
    {
        rayMgr = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayMgr.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), hits, TrackableType.PlaneWithinPolygon);

        // If I hit an AR plane surface, set the position and rotation
        // Take just the first hit
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
