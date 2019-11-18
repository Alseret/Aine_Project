using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Roll : MonoBehaviour
{
	[Header("Child...")]
	[SerializeField] private RectTransform m_roll;
	[SerializeField] private RectTransform m_roll_debug;
	[SerializeField] private float m_speed;
	[SerializeField] private GamePad_Controller m_pad;
	[SerializeField] private float m_value;
	[SerializeField] private float m_oldAngle;
	[SerializeField] private float m_amount;
	[SerializeField] private int m_cnt;
	[SerializeField] private int m_cntD;
	[SerializeField] private float m_s;
	[SerializeField] private bool m_Right;
	[SerializeField] private bool m_Up;
	[SerializeField] private bool m_Left;
	[SerializeField] private bool m_Down;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(MeasuNum());
	}

	// Update is called once per frame
	void Update()
	{
		CheckVector();
		m_roll_debug.eulerAngles = new Vector3(0f, 0f, m_pad.m_angle);
		if ((m_pad.m_angle != m_oldAngle) && (Mathf.Abs(m_pad.m_angle - m_oldAngle) < m_amount))
		{
			m_cnt++;
			//m_cntD++;
		}
		//if(Mathf.Abs(m_pad.m_angle - m_oldAngle) != 0f)
		//	Debug.Log("amount : " + Mathf.Abs(m_pad.m_angle - m_oldAngle));

		m_oldAngle = m_pad.m_angle;
		m_roll.Rotate(Vector3.forward, Time.deltaTime * m_cntD);
	}
	private void CheckVector()
	{
		if (m_pad.GetPad_VectorUp() && !m_Up)
		{
			m_Up = true;
			m_Left = false;
			m_Down = false;
			m_Right = false;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorLeft() && !m_Left)
		{
			m_Up = false;
			m_Left = true;
			m_Down = false;
			m_Right = false;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorDown() && !m_Down)
		{
			m_Up = false;
			m_Left = false;
			m_Down = true;
			m_Right = false;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorRight() && !m_Right)
		{
			m_Up = false;
			m_Left = false;
			m_Down = false;
			m_Right = true;
			m_cntD++;
		}
	}
	private IEnumerator MeasuNum()
	{
		yield return new WaitForSeconds(1f);
		m_s = m_cnt / 1f;
		m_cnt = 0;
		StartCoroutine(MeasuNum());
	}
}