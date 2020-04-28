using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 offset;

    private GameObject NatureSetting;
    private GameObject natureHuman;
    private GameObject natureSpirit;
    private GameObject industrialHuman;
    private GameObject industrialSpirit;

    void Start()
    {
        NatureSetting = GameObject.Find("NatureWorld");
    }


    void LateUpdate()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 pointToReach = GetCenterPoint() + offset;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, pointToReach.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, pointToReach.x, interpolation);

        this.transform.position = position;
    }

    private Vector3 GetCenterPoint()
    {
        if (NatureSetting.activeSelf)
        {
            natureHuman = GameObject.Find("NatureHuman");
            industrialSpirit = GameObject.Find("IndustrialSpirit");

            var bounds = new Bounds(natureHuman.transform.position, Vector3.zero);
            bounds.Encapsulate(industrialSpirit.transform.position);

            return bounds.center;
        }
        else
        {
            natureSpirit = GameObject.Find("NatureSpirit");
            industrialHuman = GameObject.Find("IndustrialHuman");
     
            var bounds = new Bounds(industrialHuman.transform.position, Vector3.zero);
            bounds.Encapsulate(natureSpirit.transform.position);

            return bounds.center;
        }
    }
}