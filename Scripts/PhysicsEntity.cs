using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEntity : MonoBehaviour {

    private Rigidbody m_rb = null;
    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
    }

    public void VelocityDriven(float speed)
    {
        Vector3 forwardVelocity = speed * transform.forward;
        Vector3 strafeVelocity = (Input.GetAxis("Horizontal") * speed) * transform.right;
        m_rb.velocity = forwardVelocity;
    }

    public void ForceDriven(float acceleration)
    {
        Vector3 forwardAcceleration = acceleration * transform.forward;
        Vector3 strafeAcceleration = (Input.GetAxis("Horizontal") * acceleration) * transform.right;
        m_rb.AddForce(forwardAcceleration, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
