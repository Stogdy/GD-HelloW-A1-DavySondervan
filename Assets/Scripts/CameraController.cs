using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private float sensitivity = 1.0f;
    private void Start()
    {
        this.camera = Camera.main;
        camera.transform.parent = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mX * sensitivity, 0);
        camera.transform.Rotate(mY* sensitivity, 0, 0);
    }
}
