using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Character : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_speed;
    [SerializeField] private float jump_max_amount;
    private Rigidbody _rigidbody;
    private GameController gameController;
    private MeshRenderer _renderer;
    [SyncVar] private Color _color;
    private bool isJump = false;
    private float jump = 0;
    private float jump_amount = 0;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
        _color = _renderer.materials[0].color;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_renderer.materials[0].color != _color)            
            _renderer.materials[0].color = _color;
        if (this.isLocalPlayer)
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

    public void SetColor(Color color)
    {
        _color = color;
    }
}
