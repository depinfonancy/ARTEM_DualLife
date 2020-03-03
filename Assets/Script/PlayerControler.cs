﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    private float horizontalMove = 0f;

	private bool lookRight = true;
    private bool jump = false;
    private bool onGround = true;

    public string originalWorld;
    public float playerSpeed = 5f;
    public float jumpForce = 10f;


    void Start()
    {
		m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
	}

    void Update()
    {
        horizontalMove = Input.GetAxis(originalWorld + "Horizontal") * playerSpeed;
        if(Input.GetButtonDown("Jump") && onGround)
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {
        // Move our character
        if (jump)
        { 
            m_rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            m_animator.SetBool("isJumping", false);
            jump = false;
        }

        Vector3 move = new Vector3(horizontalMove, m_rigidbody.velocity.y, 0.0f);
        m_rigidbody.velocity = move;
        if (horizontalMove == 0)
        {
            m_animator.SetBool("isWalking", false);
        }
        else
        {
            m_animator.SetBool("isWalking", true);
            if ((lookRight && horizontalMove < 0.0f) || (!lookRight && horizontalMove > 0.0f))
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        lookRight = !lookRight;
        transform.localScale = scale;
    }

}
