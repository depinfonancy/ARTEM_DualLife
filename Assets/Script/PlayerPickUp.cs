using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    private bool canPickUp = false;

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
            canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable" && canPickUp)
        {
            GetComponent<PlayerControler>().inventory.Add(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}

