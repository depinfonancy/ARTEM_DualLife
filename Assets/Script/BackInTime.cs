using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTime : MonoBehaviour
{

    private Collider2D m_collider2D;
    private GameObject player;
    private bool revive = false;

    public float waiting_time = 1f;


    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (revive)
        {
            StartCoroutine("Revive");
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

    IEnumerator Revive()
    {
        //Freeze Player
        Rigidbody2D player_rigidbody2D = player.gameObject.GetComponent<Rigidbody2D>();
        player_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        player.gameObject.GetComponent<PlayerControler>().enabled = false;
        

        //Start Particule
        yield return new WaitForSeconds(waiting_time);
        player.GetComponent<SpriteRenderer>().enabled = false;
        //End Particule


        //Camera travelling
        yield return new WaitForSeconds(waiting_time);

        player.transform.position = transform.GetChild(0).position;
        player_rigidbody2D.constraints = RigidbodyConstraints2D.None;
        player_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        int i = 0;
        while (i++ < 1000) { }


        //Start Particule
        yield return new WaitForSeconds(waiting_time);
        player.GetComponent<SpriteRenderer>().enabled = true;
        //End Particule

        i = 0;
        while (i++ < 1000) { }

        player.gameObject.GetComponent<PlayerControler>().enabled = true;
 
        revive = false;
    }

}
