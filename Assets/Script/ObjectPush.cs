using UnityEngine;
using System.Collections;

public class ObjectPush : MonoBehaviour {

		public bool beingPushed;
		float xPos;

		public Vector3 lastPos;


	void Start () {
				xPos = transform.position.x;
				lastPos = transform.position;
	}
	

	void FixedUpdate () {

						if (beingPushed == false) {
								transform.position = new Vector3 (xPos, transform.position.y);
						} else
								xPos = transform.position.x;

	
	}
	
}
