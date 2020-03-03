using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
	private float delay;
	public float maxDelay = 5f;

	private GameObject currentSetting;
    private GameObject nextSetting;

    private GameObject natureHuman;
    private GameObject natureSpirit;
    private GameObject industrialHuman;
    private GameObject industrialSpirit;

	void Start()
	{

        currentSetting = GameObject.Find("NatureWorld");
        nextSetting = GameObject.Find("IndustrialWorld");

        natureHuman = GameObject.Find("NatureHuman");
        natureSpirit = GameObject.Find("NatureSpirit");
        industrialHuman = GameObject.Find("IndustrialHuman");
        industrialSpirit = GameObject.Find("IndustrialSpirit");

        delay = maxDelay;
		nextSetting.transform.gameObject.SetActive(false);
	}

	void Update()
	{
		delay += Time.deltaTime;
        //GetButtonDown/Up true when keypress
        if (Input.GetButton("ChangeDimNature") && Input.GetButton("ChangeDimIndustry") && maxDelay < delay)
		{
			Switch();
			delay = 0f;
		}
	}

	void Switch()
	{
		nextSetting.transform.gameObject.SetActive(true);

		Vector3 pos1 = natureSpirit.transform.position;
		natureSpirit.transform.position = natureHuman.transform.position;
		natureHuman.transform.position = pos1;

		Vector3 pos2 = industrialSpirit.transform.position;
		industrialSpirit.transform.position = industrialHuman.transform.position;
		industrialHuman.transform.position = pos2;

		currentSetting.transform.gameObject.SetActive(false);

		GameObject tmpObject = currentSetting;
		currentSetting = nextSetting;
		nextSetting = tmpObject;

	}
}
