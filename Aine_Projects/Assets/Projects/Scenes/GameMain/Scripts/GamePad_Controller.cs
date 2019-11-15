﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad_Controller : MonoBehaviour
{
	[SerializeField] private float m_x;
	[SerializeField] private float m_y;
	[SerializeField] public float m_angle;
	[SerializeField] public Vector3 m_vec;
	[SerializeField] private Transform m_target;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		m_x = Input.GetAxis("Vertical2");
		m_y = Input.GetAxis("Horizontal2");
		//m_angle = Input.GetAxis("Horizontal2");

		//m_vec = new Vector3(Mathf.Sin(m_y * 180f * Mathf.Deg2Rad), 0f, Mathf.Cos(m_y * 180f * Mathf.Deg2Rad));
		if (m_x != 0f || m_y != 0f)
			m_angle = Mathf.Atan2(-m_x, m_y) * Mathf.Rad2Deg;


		if(m_angle < 0)
		{
			m_angle = m_angle + 360;
		}
		if(m_target)
		{
			m_target.eulerAngles = new Vector3(0f, m_angle, 0f);
		}


	}
}