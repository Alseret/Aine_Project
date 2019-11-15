using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Roll : MonoBehaviour
{
	[Header("Child...")]
	[SerializeField] private RectTransform m_roll;
	[SerializeField] private float m_speed;
	[SerializeField] private GamePad_Controller m_pad;
	[SerializeField] private float m_value;
	[SerializeField] private float m_oldAngle;
	[SerializeField] private float m_amount;
	[SerializeField] private int m_cnt;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		m_roll.eulerAngles = new Vector3(0f, 0f, m_pad.m_angle);
		if((m_pad.m_angle != m_oldAngle) && (Mathf.Abs(m_pad.m_angle - m_oldAngle) < m_amount))
		{
			m_cnt++;
		}

		m_oldAngle = m_pad.m_angle;
	}
}