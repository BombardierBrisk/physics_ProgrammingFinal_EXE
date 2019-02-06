using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public float speed = 5.0f;
    public float acceleration = 5.0f;
    public float lookAtDistance = 20.0f;
    public float stopThreshold = 3.0f;

    private bool m_isRunning = false;
    PhysicsEntity m_physicsEntity = null;
    // Use this for initialization
    void Start () {
        m_physicsEntity = GetComponent<PhysicsEntity>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning = !m_isRunning;
        }
	}

    float GetDistanceToTarget()
    {
        float distance = 0.0f;
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,transform.forward * lookAtDistance, out hitInfo))
        {
            distance = Vector3.Distance(transform.position, hitInfo.transform.position);
        }
        return distance;
    }

    void FixedUpdate()
    {
        if(m_isRunning)
        {
            float distance = GetDistanceToTarget();
            float ratio = distance < stopThreshold ? 0.0f : distance / lookAtDistance;
            m_physicsEntity.ForceDriven(ratio * acceleration);
        }
    }
}
