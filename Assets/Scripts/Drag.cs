using UnityEngine;
using System.Collections;
using System;

public class Drag : MonoBehaviour
{
    // Use this for initialization
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseUp()
    {
        float angle = GameObject.Find("Main Camera").GetComponent<CameraRotate>().getAngle();
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = new Vector3(scrSpace.x - Input.mousePosition.x, 0, scrSpace.y - Input.mousePosition.y);
        float dist = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
        offset /= dist;

        if (offset.z > 0) angle = (angle + Mathf.Rad2Deg * Mathf.Acos(offset.x)) % 360;
        else angle = (angle + 360 - Mathf.Rad2Deg * Mathf.Acos(offset.x)) % 360;
        offset.x = Mathf.Cos(Mathf.Deg2Rad * angle); offset.z = Mathf.Sin(Mathf.Deg2Rad * angle);
        offset *= dist; offset.y = 6;
        Debug.Log(angle);

        rb.AddForce(offset, ForceMode.Impulse);
    }

}