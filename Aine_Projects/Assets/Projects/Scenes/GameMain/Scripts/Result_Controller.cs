using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result_Controller : MonoBehaviour
{
	[SerializeField] private Image m_capture;
	[SerializeField] private ScreenShot m_scrShot;

	// Start is called before the first frame update
	void Start()
	{
		m_scrShot = GameObject.Find("Cam").GetComponent<ScreenShot>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			m_capture.sprite = m_scrShot.m_sprite;
			transform.GetChild(0).GetComponent<Image>().enabled = true;
			transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
			transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
		}
	}
}