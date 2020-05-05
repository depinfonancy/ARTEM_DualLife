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

    private string worldName;
    private GameObject target;

    public GameObject objectsLayout;
    public GameObject created_obj;

    public bool dectectInBothWorld = false;
    public bool alreadyExist = false;

    public float maxDistance = 2f;
    public float alphaChanDetectLim = 0.7f;
    public float TimeNeedDetect = 3f;
    
    
    private void Start()
    {
        worldName = gameObject.transform.parent.transform.parent.name;

        if (worldName == "NatureWorld")
        {
            target = GameObject.Find("IndustrialSpirit");
        }
        else
        {
            target = GameObject.Find("NatureSpirit");
        }

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
                if(worldName == "NatureWorld")
                {
                    int ind = int.Parse(transform.name.Substring(15));
                    Transform gm = objectsLayout.transform.GetChild(ind);
                    Destroy(gm.gameObject);
                }
                else
                {
                    int ind = int.Parse(transform.name.Substring(15));
                    Transform gm = objectsLayout.transform.GetChild(ind);
                    Destroy(gm.gameObject);
                }

            }
            GameObject obj = Instantiate(created_obj, objectsLayout.transform);
            obj.transform.position = transform.position;
            created = true;
        }

        m_sprite.color = new Color(color.r, color.g, color.b, alphaChan);

    }

}
