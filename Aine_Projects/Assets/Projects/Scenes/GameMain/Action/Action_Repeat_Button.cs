using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Repeat_Button : MonoBehaviour
{
	[SerializeField] public GameObject[] m_imageObj;
	[SerializeField] private Action_Repeat m_master;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (m_master.m_action)
		{
			m_imageObj[0].SetActive(false);
			m_imageObj[1].SetActive(true);
		}
		if (!m_master.m_action)
		{
			m_imageObj[0].SetActive(true);
			m_imageObj[1].SetActive(false);
		}
	}
}