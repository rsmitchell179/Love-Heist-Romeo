using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// tutorial:
// https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/

public class cameraFollow : MonoBehaviour
{

    public Transform cameraFollows;

    // background object has a box collider, so we can know
    // the limits of the room size
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthSize, camRatio;
    private Camera cam; //hey thats me!

    // Start is called before the first frame update
    void Start()
    {
        // set camera borders so it stays in the room
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        // get our camera so we can fiddle with it
        cam = GetComponent<Camera>();

        // vertical size of camera
        camOrthSize = cam.orthographicSize;
        
        // horizontal size (determined by ratio)
        camRatio = (xMax + camOrthSize) / 2.0f;
    }

    void FixedUpdate()
    {
        // offset camera by half, to keep followed object in center
        camY = Mathf.Clamp(cameraFollows.position.y, yMin + camOrthSize, yMax - camOrthSize);
        camX = Mathf.Clamp(cameraFollows.position.x, xMin + camRatio, xMax - camRatio);

        // move camera into place
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
