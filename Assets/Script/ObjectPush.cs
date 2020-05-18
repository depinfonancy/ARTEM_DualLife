using UnityEngine;
using System.Collections;

public class ObjectPush : MonoBehaviour {

    public bool beingPushed;
    float xPos;

	void Start ()
    {
		xPos = transform.position.x;
	}
	

	void FixedUpdate ()
    {
  
		if (beingPushed == false) {
				transform.position = new Vector3 (xPos, transform.position.y);
		} else
				xPos = transform.position.x;
	}
	
}
