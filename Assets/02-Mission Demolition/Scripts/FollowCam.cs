using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //POI is the point of interest that the cam follows

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamicallly")]
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    //Trying to allow early rest of camera OnMouseDown()


    void FixedUpdate()
    {
        //if (POI == null) return;
        //Vector3 destination = POI.transform.position;

        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        } else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing); //adds interpolation
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            POI = null;
            return;
        }
    }
}
