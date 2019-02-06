using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public Vector3 initialVelocity = Vector3.zero;

    private bool m_isLaunched = false;
    private Vector3 m_startPosition = Vector3.zero;
    private Vector3 m_displacement = Vector3.zero;
    private float m_timeToDisplacement = 0.0f;
    private float m_startTime = 0.0f;
    public Rigidbody m_rb = null;
    public float speed;
    PhysicsEntity m_physicsEntity = null;
    bool isLaunching = false;

    public Slider healthbar;
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public Text text_Speed;
    public Vector3 movement;
    public float jump_Force;

    public Transform transformA;
    public Transform transformB;

    public Text text_Distance;
    public Text text_Winner;
    // public float delete_speed;

    // Use this for initialization
    void Start () {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        m_physicsEntity = GetComponent<PhysicsEntity>();
        m_rb = GetComponent<Rigidbody>();
        text_Speed.text = movement.ToString();
        text_Distance.text = Vector3.Distance(transformA.position, transformB.position).ToString();
        text_Winner.text = "";

    }
	
	// Update is called once per frame
	void Update () {

        

        if(Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(3);
        }
            
		
  //      else if(Input.GetKeyDown(KeyCode.Alpha1))
  //      {
  //          m_rb.velocity = PhysicsHelper.CalculateInitialVelocity(m_displacement, m_timeToDisplacement, Physics.gravity);
  //          m_isLaunched = true;
  //          m_startTime = Time.timeSinceLevelLoad;
  //          m_startPosition = transform.position;
  //      }
  //      else if (Input.GetKeyDown(KeyCode.Alpha2))
  //      {
  //          Vector3 desiredVelocity = PhysicsHelper.CalculateInitialVelocity(m_displacement, m_timeToDisplacement, Physics.gravity);
  //          Vector3 impulseForce = PhysicsHelper.CalculateForce(m_rb.velocity, desiredVelocity, Time.fixedDeltaTime,m_rb.mass);
  //          m_rb.AddForce(impulseForce);
  //          m_isLaunched = true;
  //          m_startTime = Time.timeSinceLevelLoad;
  //          m_startPosition = transform.position;
  //      }

  
    }

    private bool IsGrounded()
    {
        bool _isGrounded = false;

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<SphereCollider>().bounds.extents.y + 0.1f); // player position. raycast pointing. shape collider. targets another plus a little bit more
        return _isGrounded;

}

private void FixedUpdate()
    { 

        float moveHorizontal = Input.GetAxisRaw("Vertical");
        float moveVertical = Input.GetAxisRaw("Horizontal");

        movement = new Vector3(moveHorizontal, 0.0f, -moveVertical);
        text_Speed.text = movement.ToString();
        text_Distance.text = Vector3.Distance(transformA.position, transformB.position).ToString();

        if (isLaunching == true)
        {
            m_rb.AddForce(0, LauchPadScript.launchSpeed, 0);
            isLaunching = false;
        }

        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded()) 
        {
            movement = new Vector3(moveHorizontal, jump_Force, -moveVertical);
            m_rb.AddForce(movement * speed);
           // m_rb.velocity = initialVelocity;
           // m_isLaunched = true;
           // m_startPosition = transform.position;
           // m_startTime = Time.timeSinceLevelLoad;
        }
       
          m_rb.AddForce(movement * speed);
        if (m_isLaunched)
       {
            if(m_rb.velocity.y < Mathf.Epsilon)
            {
             m_displacement = transform.position - m_startPosition;
             float displacementLength = m_displacement.magnitude;
             m_timeToDisplacement = Time.timeSinceLevelLoad - m_startTime;
                
              // Debug.Log("Time: " + m_timeToDisplacement);
              // Debug.Log("Displacement: " + m_displacement);
              // Debug.Log("Displacement Length: " + displacementLength);

               m_isLaunched = false;
            }
       }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Launchpad")
        {
            isLaunching = true;
            Debug.Log("Launching");
        }

        if(other.tag == "Teleport")
        {
            React();
        }
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageWall")
        {
            DealDamage(3);
           // healthbar.value = CalculateHealth();
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
        if (collision.gameObject.tag == "DamageRotar")
        {
            DealDamage(20);
            // healthbar.value = CalculateHealth();
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        if (collision.gameObject.tag == "Win")
        {
            text_Winner.text = "YOU WIN!";
            Debug.Log("winn");
        }
    }

    void DealDamage(float damageHealth)
    {
        CurrentHealth -= damageHealth;
        healthbar.value = CalculateHealth();
    }

    void Die()
    {
        CurrentHealth = 0;
        Application.LoadLevel(0);
    }

    void React()
    {

        transform.position = new Vector3(1319.1f, -34.6f, 219.1f);

    }

}
