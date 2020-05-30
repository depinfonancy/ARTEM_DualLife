using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlate : MonoBehaviour
{

    private Animator m_animator;

    public GameObject[] actionnable;

    private bool allActionsDone = false;


    void Start()
    {
        m_animator = GetComponent<Animator>();    
    }

    private void OnCollisionStay2D(Collision2D other)
    { 
        if(!allActionsDone && other.gameObject.tag == "Pushable")
        {
            Transform self = this.transform;
            Transform box = other.gameObject.transform;
            if(self.position.x-1 < box.position.x && self.position.x + 1 > box.position.x)
            {
                //m_animator.SetBool("isActivate", true);
                for(int i = 0; i < actionnable.Length; i++)
                {
                    actionnable[i].GetComponent<ColliderToTriggerObstacle>().Action("open");
                }

                allActionsDone = true;
            }   
        }
    }
}
