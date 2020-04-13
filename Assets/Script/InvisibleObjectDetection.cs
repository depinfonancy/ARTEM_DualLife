using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObjectDetection : MonoBehaviour
{
    private SpriteRenderer m_sprite;

    private Color color;
    private float alpha_chan = 0f;
    private Vector3 objCoord;
    private Vector3 targetCoord;
    private float time_spend_waiting = 0f;
    private bool already_created = false;


    public GameObject target;
    public GameObject parent;
    public GameObject created_box;

    public float maxDistance = 2f;
    public float alpha_chan_lim = 0.7f;
    public float waiting_time_lim = 3f;
    
    
    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        color = m_sprite.color;
        m_sprite.color = new Color(color.r, color.g, color.b, alpha_chan);
    }

    private void Update()
    {
        objCoord = transform.position;
        targetCoord = target.transform.position;
        Vector3 tmp = objCoord - targetCoord;

        //Define the value of alpha channel
        if(tmp.magnitude < maxDistance)
        {
            alpha_chan = 1 - tmp.magnitude / maxDistance;
        }
        else
        {
            alpha_chan = 0f;
        }

        //Define the time spend with an alpha channel with a certain value
        if (alpha_chan >= alpha_chan_lim)
        {
            time_spend_waiting += Time.deltaTime;
        }
        else
        {
            time_spend_waiting = 0f;
        }

        //Generation of the box
        if(time_spend_waiting >= waiting_time_lim && !already_created)
        {
            GameObject box = Instantiate(created_box, parent.transform);
            box.transform.position = transform.position;
            already_created = true;
        }

        m_sprite.color = new Color(color.r, color.g, color.b, alpha_chan);

    }

}
