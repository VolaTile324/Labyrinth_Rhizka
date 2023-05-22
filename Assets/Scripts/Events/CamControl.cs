using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject ball;
    float frustumScale;

    private void Start()
    {
        var camDistance = cam.transform.position.y;
        var frustumHeight = 2.0f * camDistance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        frustumScale = frustumHeight / Screen.height;
    }

    private void Update()
    {
        var touches = Input.touches;

        /* switch (touches.Length)
        {
            case 1:
                Drag(touches);
                break;
            case 2:
                Zoom(touches);
                break;
        } */

        if (touches.Length == 2)
        {
            Zoom(touches);
        }

        cam.transform.position = new Vector3(ball.transform.position.x, cam.transform.position.y, ball.transform.position.z);
    }

    /* private void Drag(UnityEngine.Touch[] touches)
    {
        var touch = Input.GetTouch(0);
        cam.transform.position -= new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y) * frustumScale;
    } */

    private void Zoom(UnityEngine.Touch[] touches)
    {
        var prevPos0 = touches[0].position - touches[0].deltaPosition;
        var prevPos1 = touches[1].position - touches[1].deltaPosition;
        var previousDist = Vector2.Distance(prevPos0, prevPos1);
        var currentDist = Vector2.Distance(touches[0].position, touches[1].position);
        var deltaDist = currentDist - previousDist;

        if (cam.orthographic)
        {
            cam.orthographicSize -= deltaDist * 0.1f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2, 15);
        }
        else
        {
            var camDist = cam.transform.position.y;
            var frustumHeight = 2 * camDist * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
            frustumScale = frustumHeight / Screen.height;

            cam.transform.position -= Vector3.up * deltaDist * frustumScale;
            var y = Mathf.Clamp(cam.transform.position.y, 10, 100);
            cam.transform.position = new Vector3(cam.transform.position.x, y, cam.transform.position.z);
        }
    }
}
