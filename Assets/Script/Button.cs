using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator m_animator;

    public GameObject[] actionnable;

    private bool allActionsDone = false;
    private bool buttonDown = false;
    private bool inZone = false;
    private string worldName;


    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetWorld();

        if (Input.GetButton(worldName + "Interaction"))
        {
            buttonDown = true;
        }
        else
        {
            buttonDown = false;
        }

        if (buttonDown && inZone)
        {
            RunActions();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            inZone = false;
        }
    }

    private void RunActions()
    {
        m_animator.SetBool("IsTurning", true);
        if (!allActionsDone)
        {
            for (int i = 0; i < actionnable.Length; i++)
            {
                actionnable[i].GetComponent<PlateformTranslation>().Action("open");
            }
            allActionsDone = true;
        }
        else
        {
            for (int i = 0; i < actionnable.Length; i++)
            {
                actionnable[i].GetComponent<PlateformTranslation>().Action("close");
            }
            allActionsDone = false;
        }
    }

    private void GetWorld()
    {
        GameObject world = GameObject.Find("IndustrialWorld");

        if (world != null)
        {
            worldName = "Industry";
        }
        else
        {
            worldName = "Nature";
        }
    }
}
