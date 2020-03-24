using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour {

		public float distance=1f;
		public LayerMask ObjectMask;

		GameObject PushPullObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
				Physics2D.queriesStartInColliders = false;
				RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, ObjectMask);
	
				if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown (KeyCode.E)) {


						PushPullObject = hit.collider.gameObject;
						PushPullObject.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
						PushPullObject.GetComponent<FixedJoint2D> ().enabled = true;
						PushPullObject.GetComponent<ObjectPush> ().beingPushed = true;

				} else if (Input.GetKeyUp (KeyCode.E)) {
						PushPullObject.GetComponent<FixedJoint2D> ().enabled = false;
						PushPullObject.GetComponent<ObjectPush> ().beingPushed = false;
				}
		
		}


}
