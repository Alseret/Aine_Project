using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Roll : Action_Mono
{
	[System.Serializable]
	public enum VECTOR_ROLL
	{
		RIGHT,
		UP,
		LEFT,
		DOWN,
	}
	[Header("Child...")]
	[SerializeField] private RectTransform m_roll;
	[SerializeField] private RectTransform m_roll_debug;
	[SerializeField] private GamePad_Controller m_pad;
	[SerializeField] private int m_cntD;
	[SerializeField] private float m_s;
	[SerializeField] private VECTOR_ROLL m_vec;

	// Start is called before the first frame update
	void Start()
	{
		Setup();
		m_pad = GameObject.Find("GameManager").GetComponent<GamePad_Controller>();
		m_type = GameManager._ACTION_TYPE.Roll;
		StartCoroutine(MeasuNum());
		ResetValue();
	}

	// Update is called once per frame
	void Update()
	{
		CheckVector();
		m_roll_debug.eulerAngles = new Vector3(0f, 0f, m_pad.m_angle);
		m_roll.Rotate(Vector3.forward, Time.deltaTime * m_cnt);
	}
	private void CheckVector()
	{
		if (m_pad.GetPad_VectorUp() && m_vec != VECTOR_ROLL.UP)
		{
			m_vec = VECTOR_ROLL.UP;
			m_cnt++;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorLeft() && m_vec != VECTOR_ROLL.LEFT)
		{
			m_vec = VECTOR_ROLL.LEFT;
			m_cnt++;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorDown() && m_vec != VECTOR_ROLL.DOWN)
		{
			m_vec = VECTOR_ROLL.DOWN;
			m_cnt++;
			m_cntD++;
		}
		else if (m_pad.GetPad_VectorRight() && m_vec != VECTOR_ROLL.RIGHT)
		{
			m_vec = VECTOR_ROLL.RIGHT;
			m_cnt++;
			m_cntD++;
		}
	}
	private IEnumerator MeasuNum()
	{
		yield return new WaitForSeconds(1f);
		m_s = m_cntD / 1f;
		m_cntD = 0;
		StartCoroutine(MeasuNum());
	}
}