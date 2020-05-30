using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToTriggerObstacle: MonoBehaviour
{

    public string[] animation_order = { "isDisappering" };

    private Collider2D m_collider;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_animator = GetComponent<Animator>();
    }

    public void Action(string act)
    {
        if(act == "open")
        {
            foreach(string cmd in animation_order)
            {
                m_animator.SetBool(cmd, true);
            }
        }
    }

    public void ToTriggerCollider()
    {
        m_collider.isTrigger = true;
    }
}
