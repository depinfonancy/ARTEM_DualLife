using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObjectDetection : MonoBehaviour
{
    private SpriteRenderer m_sprite;

    private Color color;
    private float alphaChan = 0f;
    private float timeSpendWait = 0f;
    private bool created = false;


    public GameObject target;
    public GameObject parent;
    public GameObject created_box;

    public bool dectectInBothWorld = false;
    public bool alreadyExist = false;

    public float maxDistance = 2f;
    public float alphaChanDetectLim = 0.7f;
    public float TimeNeedDetect = 3f;
    
    
    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        color = m_sprite.color;
        m_sprite.color = new Color(color.r, color.g, color.b, alphaChan);
    }

    private void Update()
    {
        if (dectectInBothWorld)
        {
            alreadyExist = false;
        }

        Vector3 tmp = transform.position - target.transform.position;

        //Define the value of alpha channel
        if(tmp.magnitude < maxDistance)
        {
            alphaChan = 1 - tmp.magnitude / maxDistance;
        }
        else
        {
            alphaChan = 0f;
        }

        //Define the time spend with an alpha channel with a certain value
        if (alphaChan >= alphaChanDetectLim)
        {
            timeSpendWait += Time.deltaTime;
        }
        else
        {
            timeSpendWait = 0f;
        }

        //Generation of the box
        if(timeSpendWait > TimeNeedDetect && !created && !alreadyExist)
        {
            if (dectectInBothWorld)
            {
                GameObject gm = GameObject.Find(parent.transform.parent.name + "/" + parent.name + "/" + name);
                Destroy(gm);
            }
            GameObject box = Instantiate(created_box, parent.transform);
            box.transform.position = transform.position;
            created = true;
        }

        m_sprite.color = new Color(color.r, color.g, color.b, alphaChan);

    }

}
