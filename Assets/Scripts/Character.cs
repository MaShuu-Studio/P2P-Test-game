using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Character : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_speed;
    [SerializeField] private float jump_max_amount;
    private Rigidbody rigidbody3d;
    private GameController gameController;
    private Renderer renderer;
    private bool isJump = false;
    private float jump = 0;
    private float jump_amount = 0;
    
    void Start()
    {
        rigidbody3d = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        //gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //renderer.materials[0] = gameController.SetColor();
        Debug.Log(NetworkClient.connection.connectionId);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.isLocalPlayer)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            if (Input.GetButtonDown("Jump") && isJump == false)
            {
                isJump = true;
                jump = jump_speed;
            }
            transform.position += new Vector3(speed * moveX, jump, speed * moveZ);
            if (isJump)
            {
                jump_amount += jump;
                if (jump_amount >= jump_max_amount) jump = 0;
                if (transform.position.y <= 0.001f) 
                {
                    jump_amount = 0;
                    isJump = false;
                }
            }
        }
    }
}
