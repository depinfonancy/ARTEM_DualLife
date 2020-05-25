using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformTranslation : MonoBehaviour
{
    private Vector3 origTarget;
    private Vector3 currentTarget;
    private Vector3 openedTarget;
    private Vector3 closedTarget;
    private Vector3 velocity;

    private bool opened = false;

    public float speed = 0.4f;
    public float smoothTime = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        closedTarget = transform.position;
        openedTarget = transform.Find(name + "Target").position;

        currentTarget = closedTarget;
        origTarget = openedTarget;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isOpening = true;
    //    currentTarget = openedTarget;
    //    origTarget = closedTarget;

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isOpening = false;
    //    currentTarget = closedTarget;
    //    origTarget = openedTarget;
    //}

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.05f)
        {
            Vector3 direction = (currentTarget - transform.position).normalized;
            float norm = (currentTarget - transform.position).magnitude;
            if (norm > 0.05f + speed * Time.fixedDeltaTime)
                norm = speed * Time.fixedDeltaTime;
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + (norm * direction), ref velocity, smoothTime);
        }
    }

    public void Action(string act)
    {
        if (!opened && act == "open")
        {
            currentTarget = openedTarget;
            origTarget = closedTarget;
            opened = true;
        }

        if (opened && act == "close")
        {
            currentTarget = closedTarget;
            origTarget = openedTarget;
            opened = false;
        }
    }
}

