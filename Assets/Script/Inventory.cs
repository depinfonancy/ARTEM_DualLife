using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> m_inventory;

    private void Start()
    {
        m_inventory = new List<GameObject>(); 
    }

    public void AddItem(GameObject obj)
    {
        m_inventory.Add(obj);
    }

    public bool IsIn(GameObject target)
    {
        foreach (GameObject obj in m_inventory)
        {
            if (obj == target)
            {
                return true;
            }
        }
        return false;
    }
}
