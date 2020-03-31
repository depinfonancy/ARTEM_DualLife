using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTime : MonoBehaviour
{

    private Collider2D m_collider2D;

    public GameObject currentHumanPlayer;
    public GameObject currentSpiritPlayer;

    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "HumanPlayer")
        {
            Debug.Log("Need to be revive ...");
            currentHumanPlayer.GetComponent<PlayerControler>().enabled = false;
            currentSpiritPlayer.GetComponent<SpiritControler>().enabled = false;
        }        
    }

}
