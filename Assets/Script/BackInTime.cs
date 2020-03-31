using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTime : MonoBehaviour
{

    private Collider2D m_collider2D;

    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Need to be revive ...");
            other.gameObject.GetComponent<Rigidbody2D>();
            other.gameObject.GetComponent<PlayerControler>().enabled = false;
        }
    }

}
