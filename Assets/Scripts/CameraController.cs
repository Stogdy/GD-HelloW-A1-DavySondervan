using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField]
    private float sensitivity = 1.0f;
    private void Start()
    {

       // mainCamera.transform.parent = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");
      //  float mZ = Input.GetAxis("Mouse Z");
        transform.Rotate(0, mX * sensitivity, 0);
        //camera.transform.Rotate(mY* sensitivity, 1, 1);
        if (Mathf.Abs(mY) < 4.5f)
        {
            mainCamera.transform.Rotate(-mY * sensitivity, 0, 0);
            Debug.Log(mY + " " + mainCamera.transform.rotation.eulerAngles);
        }
    }
}
