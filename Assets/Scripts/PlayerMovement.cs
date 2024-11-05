using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        transform.position += movement.normalized * movementSpeed * Time.deltaTime;
    }
}
