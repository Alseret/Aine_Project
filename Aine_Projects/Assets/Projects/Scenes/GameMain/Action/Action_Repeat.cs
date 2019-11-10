using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Repeat : Action_Mono
{
	// Start is called before the first frame update
	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Repeate;
		ResetValue();
		enabled = false;
	}
	private void OnDisable()
	{
		string str = "      <size=80>" + (0) + "</size>\n    連打!!";
		ChangeCount(str);
	}

	// Update is called once per frame
	private void Update()
	{
		if (StartRepeat()) return;
		if (TimeCheck())
		{
			InputRepeat();
			TimeDecrement();
		}
	}

	// 連打
	private void InputRepeat()
	{
		if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && m_time > 0f)
		{
			string str = "      <size=80>" + (++m_cnt) + "</size>\n    連打!!";
			ChangeCount(str);
			m_cutAnim.AnimSpeed(m_cnt, m_multiply);
		}
	}
}