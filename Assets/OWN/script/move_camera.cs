using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    // Update is called once per frame

    void OnMouseDown() {
            if (Input.GetMouseButtonDown(0)) 
            {
                print(target.name);
                cam.transform.position = target.transform.position;               
            }
        }

}
