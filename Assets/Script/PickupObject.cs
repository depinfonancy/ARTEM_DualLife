using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 8) {
            print("Objet ramassé!");
            Destroy(gameObject);
        }
    }}
