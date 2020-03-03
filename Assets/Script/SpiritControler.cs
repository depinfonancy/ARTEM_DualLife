using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritControler : MonoBehaviour
{
 
	private Rigidbody2D m_rigidbody;
	private Animator m_animator;
    private Collider2D m_collider2D;

	private float horizontalMove = 0f;
    private float verticalMove = 0f;

	private bool lookRight = true;

    private string originalWorld;

    public float spiritSpeed = 5f;
	public float jumpForce = 10f;

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
        m_collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw(originalWorld + "Horizontal") * spiritSpeed;
		verticalMove = Input.GetAxisRaw(originalWorld + "Vertical") * spiritSpeed;
    }

    void FixedUpdate()
    {
        // Move our character
		Vector3 move = new Vector3(horizontalMove, verticalMove, 0.0f);
		m_rigidbody.velocity = move;
        if (horizontalMove == 0)
		{
			m_animator.SetBool("isFlying", false);
		}
		else
		{
			m_animator.SetBool("isFlying", true);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "SpecialWall")
        {
            m_collider2D.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "SpecialWall")
        {
            m_collider2D.isTrigger = false;
        }    
    }

}
