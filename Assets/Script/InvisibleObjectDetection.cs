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

    public GameObject target;
    public float maxDistance = 2;
    
    
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
        if(tmp.magnitude < maxDistance)
        {
            alpha_chan = 1 - tmp.magnitude / maxDistance;
        }
        else
        {
            alpha_chan = 0f;
        }
        Debug.Log(alpha_chan);
        m_sprite.color = new Color(color.r, color.g, color.b, alpha_chan);

    }

}
