using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour
{

 public float distance = 1f;
 public LayerMask boxMask;
 private bool canPush = false;
 GameObject box;

 // Update is called once per frame
 void Update()
 {
    if (Input.GetButton("Push")){
        canPush = true;
        Debug.Log("tu appuies sur E");
    }
    else{
        canPush = false;
    }}


void OnCollisionEnter2D(Collision2D coll)
{
  GameObject box = GameObject.FindWithTag("Pushable");
  RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
  RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);

  if (hit.collider != null && canPush)
  {

   box = hit.collider.gameObject;
   box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
   box.GetComponent<FixedJoint2D>().enabled = true;
   box.GetComponent<ObjectPush>().beingPushed = true;
   print("tu peux pousser la boîte");

  }
  else if (!canPush)
  {
   box.GetComponent<FixedJoint2D>().enabled = false;
   box.GetComponent<ObjectPush>().beingPushed = false;
  }

  if (hit2.collider != null && hit2.collider.gameObject.tag == "Pushable" && canPush)
  {

   box = hit2.collider.gameObject;
   box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
   box.GetComponent<FixedJoint2D>().enabled = true;
   box.GetComponent<ObjectPush>().beingPushed = true;

  }
  else if (!canPush)
  {
   box.GetComponent<FixedJoint2D>().enabled = false;
   box.GetComponent<ObjectPush>().beingPushed = false;
}

}}
