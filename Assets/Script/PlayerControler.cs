using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

	private bool lookRight = true;
    private bool jump = false;

    private string originalWorld;
    private Vector3 m_Velocity = Vector3.zero;

    public float playerSpeed = 5f;
    public float jumpForce = 10f;

    public List<GameObject> inventory; 

    private float movementSmoothing = .05f;


    void Start()
    {
        if (gameObject.name.Contains("Nature"))
        {
            originalWorld = "Nature";
        }
        else
        {
            originalWorld = "Industry";
        }

        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump = true;
        }

        Debug.Log(inventory); 
    }

    void FixedUpdate()
    {

        float horizontalMove = Input.GetAxis(originalWorld + "Horizontal");
        Move(horizontalMove, jump);
        jump = false;

    }

    private void Move(float move, bool jump)
    {
        bool pushing = GetComponent<PlayerPush>().pushing;

        //Walk
        if(move != 0)
        {
            if (pushing)
            {
                m_animator.SetBool("isWalking", true);
                Walk(move * playerSpeed/2, true);
            } else
            {
                m_animator.SetBool("isWalking", true);
                Walk(move * playerSpeed, false);
            }
        }
        else
        {
            m_animator.SetBool("isWalking", false);
        }

        //Jump
        if (jump && !pushing)
        {
            m_animator.SetBool("isJumping", true);
            Jump();
        }
        else
        {
            m_animator.SetBool("isJumping", false);
        }

        //Push
    }

    private void Walk(float move, bool freezeFlip)
    {
        if (!freezeFlip)
        {
            if ((lookRight && move < 0.0f) || (!lookRight && move > 0.0f))
            {
                Flip();
            }
        }

        Vector3 targetVelocity = new Vector3(move, m_rigidbody.velocity.y, 0.0f);
        m_rigidbody.velocity = Vector3.SmoothDamp(m_rigidbody.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
    }

    private void Jump()
    {
        m_rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        if (m_rigidbody.velocity.y != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        transform.localScale = scale;
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.transform.tag == "Pushable")
    //    {s
    //        canPush = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.transform.tag == "Pushable")
    //    {
    //        canPush = false;
    //    }
    //}
}