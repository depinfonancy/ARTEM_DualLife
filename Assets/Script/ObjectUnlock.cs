using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnlock : MonoBehaviour
{

    public GameObject key;
    public float eatingTime = 2f;
    public float disappearingTime = 2f;

    private Collider2D m_collider;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            GameObject player = other.gameObject;
            List<GameObject> inventory = player.GetComponent<PlayerControler>().inventory;
            foreach (GameObject obj in inventory)
            {
                if(obj == key)
                {
                    StartCoroutine("Open");
                }
            }
        }
    }

    IEnumerator Open()
    {
        m_animator.SetBool("isEating", true);
        yield return new WaitForSeconds(eatingTime);
        m_animator.SetBool("isDisappearing", true);
        yield return new WaitForSeconds(disappearingTime);
        m_collider.isTrigger = true;
    }
}
