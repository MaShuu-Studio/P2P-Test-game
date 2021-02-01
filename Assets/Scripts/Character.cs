using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Character : NetworkBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.isLocalPlayer)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            float jump = 0;
            if (Input.GetButtonDown("Jump") && rigidbody.velocity.y == 0) jump = 30;
            rigidbody.velocity = new Vector3(speed * moveX, jump, speed * moveZ);
        }
    }
}
