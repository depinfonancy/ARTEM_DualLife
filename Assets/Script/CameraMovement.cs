using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothTime = 0.3f;
    public Vector3 offset;
    public float minZoom = 2f;
    public float maxZoom = 2f;
    public float meanDistance = 2f;

    public float topLimit;
    public float bottomLimit;
    public float leftLimit;
    public float rightLimit;

    private Vector3 velocity;

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

        Move();
        //Zoom();
        Limit();

    }

    private void Move()
    {

        Vector3 target = GetCenterPoint() + offset;

        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, target.x, smoothTime);
        position.y = Mathf.Lerp(transform.position.y, target.y, smoothTime);


        transform.position = position;
        // transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);

    }

    private void Zoom()
    {
        //float interpolation = speed/4 * Time.deltaTime;

        Vector3 position = transform.position;
        float t = meanDistance / (2 * offset.z);
        float zoom = GetGreatestDistance() / (2 * t);
        position.z = Mathf.Lerp(transform.position.z, zoom, smoothTime);

        transform.position = position;

    }

    private void Limit()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            Mathf.Clamp(transform.position.z, offset.z - minZoom, offset.z + maxZoom)
        );
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

    private float GetGreatestDistance()
    {
        if (NatureSetting.activeSelf)
        {
            natureHuman = GameObject.Find("NatureHuman");
            industrialSpirit = GameObject.Find("IndustrialSpirit");

            var bounds = new Bounds(natureHuman.transform.position, Vector3.zero);
            bounds.Encapsulate(industrialSpirit.transform.position);

            if (bounds.size.x < bounds.size.y)
            {
                return bounds.size.y;
            }
            else
            {
                return bounds.size.x;
            }
        }
        else
        {
            natureSpirit = GameObject.Find("NatureSpirit");
            industrialHuman = GameObject.Find("IndustrialHuman");

            var bounds = new Bounds(industrialHuman.transform.position, Vector3.zero);
            bounds.Encapsulate(natureSpirit.transform.position);

            if (bounds.size.x < bounds.size.y)
            {
                return bounds.size.y;
            }
            else
            {
                return bounds.size.x;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));

    }
}