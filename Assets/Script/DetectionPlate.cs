using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlate : MonoBehaviour
{

    private Animator m_animator;
    private BoxCollider2D m_collider2D;

    public GameObject[] actionnable;

    private bool allActionsDone = false;


    void Start()
    {
        m_animator = GetComponent<Animator>();    
        m_collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D other)
    { 
        if(!allActionsDone && other.gameObject.tag == "Pushable")
        {
            Transform self = this.transform;
            Transform box = other.gameObject.transform;
            if(self.position.x-1 < box.position.x && self.position.x + 1 > box.position.x)
            {
                m_animator.SetBool("IsActived", true);
                m_collider2D.offset = new Vector2(m_collider2D.offset.x, -0.6f);
                m_collider2D.size = new Vector2(m_collider2D.size.x, 1.32f);

                for (int i = 0; i < actionnable.Length; i++)
                {
                    actionnable[i].GetComponent<ColliderToTriggerObstacle>().Action("open");
                }

                allActionsDone = true;
            }   
        }
    }
}
