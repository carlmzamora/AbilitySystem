using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private float defaultMoveSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    //do physics-based spring-enabled contrller eventually
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        rb.AddForce(direction * defaultMoveSpeed);
    }

    //do torque eventually
    private void Rotate()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //basically, plane orientation and plane world height
        float rayLength;

        if(groundPlane.Raycast(mouseRay, out rayLength))
        {
            Vector3 pointToLookAt = mouseRay.GetPoint(rayLength); //get point along mouseRay where it intersects with groundPlane
            transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z)); //rotate, but do not include y to avoid y axis movement
        }
    }
}
