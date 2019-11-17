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

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(MeasuNum());
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(m_pad.m_angle);
		m_roll_debug.eulerAngles = new Vector3(0f, 0f, m_pad.m_angle);
		if ((m_pad.m_angle != m_oldAngle) && (Mathf.Abs(m_pad.m_angle - m_oldAngle) < m_amount))
		{
			m_cnt++;
			m_cntD++;
		}
		//if(Mathf.Abs(m_pad.m_angle - m_oldAngle) != 0f)
		//	Debug.Log("amount : " + Mathf.Abs(m_pad.m_angle - m_oldAngle));

		m_oldAngle = m_pad.m_angle;
		m_roll.Rotate(Vector3.forward, Time.deltaTime * m_cntD);
	}
	private IEnumerator MeasuNum()
	{
		yield return new WaitForSeconds(1f);
		m_s = m_cnt / 1f;
		m_cnt = 0;
		StartCoroutine(MeasuNum());
	}
}