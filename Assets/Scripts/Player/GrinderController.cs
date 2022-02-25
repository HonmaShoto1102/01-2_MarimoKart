using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public Rigidbody parentRigidBody;Å@//ñ{ëÃ
    private float glindStartedY;
    private Vector3 glindStartedVelocity;
    public float frontforce;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            float deltaY = glindStartedY - parentRigidBody.position.y;
           
            if (deltaY >= 0)
            {
                parentRigidBody.velocity = parentRigidBody.transform.forward * Mathf.Sqrt(frontforce * Physics.gravity.magnitude * deltaY);
               
            }

        }
        else
        {
            
            parentRigidBody.useGravity = true;
            glindStartedY = parentRigidBody.position.y;
        }
    }
    private void FixedUpdate()
    {
       

    }
}
