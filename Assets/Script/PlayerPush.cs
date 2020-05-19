using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour
{

    public float distance = 1f;
    GameObject box;

    private bool canPush = false;
    public bool pushing = false;

    private string originalWorld;

    void Start()
    {
        if (gameObject.name.Contains("Nature"))
        {
            originalWorld = "Nature";
        }
        else
        {
            originalWorld = "Industry";
        }
    }

    private void Update()
    {
        if (Input.GetButton(originalWorld + "Interaction"))
        {
            canPush = true;
        }
        else
        {
            canPush = false;
        }
    }

    private void FixedUpdate()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && canPush)
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<ObjectPush>().beingPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            pushing = true;
        }

        if(pushing && !canPush)
        {
            pushing = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<ObjectPush>().beingPushed = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);

    }
}