using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField] GameObject visTemp;
    List<GameObject> visList = new List<GameObject>();
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        /* if (Input.touchCount == 0)
        {
            return;
        }

        var touches = Input.touches;
        while (visList.Count < touches.Length)
        {
            var vis = Instantiate(visTemp);
            visList.Add(vis);
        }

        foreach (var vis in visList)
        {
            vis.SetActive(false);
        }

        for (int i = 0; i < touches.Length; i++)
        {
            var touch = touches[i];
            var vis = visList[i];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Began: " + touch.position);
                    break;
                case TouchPhase.Stationary:
                    Debug.Log("Stationary: " + touch.position);
                    break;
                case TouchPhase.Moved:
                    vis.SetActive(true);
                    var worldPos = cam.ScreenToWorldPoint(touch.position);
                    worldPos.z = 0;
                    vis.transform.position = worldPos;
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Ended: " + touch.position);
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("Canceled: " + touch.position);
                    break;
            }
        } */

        /*
        if (Input.touchCount != 2)
        {
            return;
        }

        var touches = Input.touches;

        var prevPos0 = touches[0].position - touches[0].deltaPosition;
        var prevPos1 = touches[1].position - touches[1].deltaPosition;
        var prevDist = Vector2.Distance(prevPos0, prevPos1);
        var currDist = Vector2.Distance(touches[0].position, touches[1].position);
        var delta = currDist - prevDist;

        if (cam.orthographic)
        {
            cam.orthographicSize -= delta * 0.1f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2, 15);
        }
        else
        {
            cam.transform.position += Vector3.forward * delta;
            var z = Mathf.Clamp(cam.transform.position.z, -10, -1);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, z);
        }
        */

        if (Input.touchCount != 1)
        {
            return;
        }
        var touch = Input.GetTouch(0);
        cam.transform.position -= (Vector3) touch.deltaPosition * 0.001f;
    }



}
