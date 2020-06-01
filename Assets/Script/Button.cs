using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator m_animator;

    public GameObject[] actionnable;

    private bool allActionsDone = false;
    private bool canInteract = false;
    private string worldName;


    void Start()
    {
        m_animator = GetComponent<Animator>();

        Transform world = transform.Find("IndustrialWorld");

        if (world != null)
        {
            worldName = "Industry";
        }
        else
        {
            worldName = "Nature";
        }
    }

    private void Update()
    {
        if (Input.GetButton(worldName + "Interaction"))
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 8 && canInteract)
        {
            m_animator.SetBool("IsTurning", true);
            if (!allActionsDone)
            {
                for (int i = 0; i < actionnable.Length; i++)
                {
                    actionnable[i].GetComponent<PlateformTranslation>().Action("open");
                }
                allActionsDone = true;
            } else
            {
                for (int i = 0; i < actionnable.Length; i++)
                {
                    actionnable[i].GetComponent<PlateformTranslation>().Action("close");
                }
                allActionsDone = false;
            }
        }
    }
}
