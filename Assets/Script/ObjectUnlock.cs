﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnlock : MonoBehaviour
{

    public GameObject key;

    private Collider2D m_collider;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            PlayerControler player = other.gameObject.GetComponent<PlayerControler>();
            
            if(player.Have(key))
            {
                m_animator.SetBool("isEating", true);
                m_animator.SetBool("isDisappearing", true);
            }
        }
    }

    public void ToTriggerCollider()
    {
        m_collider.isTrigger = true;
    }
}
