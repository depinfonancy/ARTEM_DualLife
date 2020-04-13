using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTime : MonoBehaviour
{

    private Collider2D m_collider2D;
    private GameObject player;
    private bool revive = false;


    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (revive)
        {
            //Freeze Player
            Rigidbody2D player_rigidbody2D = player.gameObject.GetComponent<Rigidbody2D>();
            player_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            player.gameObject.GetComponent<PlayerControler>().enabled = false;

            //Particule + Disp
            int i = 0;
            while (i < 100000){
                i += 1;
            }
            player.GetComponent<SpriteRenderer>().enabled = false;

            //Camera travelling
            i = 0;
            while (i < 100000)
            {
                i += 1;
            }
            player.transform.position = transform.GetChild(0).position;


            //Particule + Appear
            player_rigidbody2D.constraints = RigidbodyConstraints2D.None;
            player_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            i = 0;
            while (i < 100000)
            {
                i += 1;
            }
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.gameObject.GetComponent<PlayerControler>().enabled = true;

            revive = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            revive = true;
            player = other.gameObject;
        }
    }

}
