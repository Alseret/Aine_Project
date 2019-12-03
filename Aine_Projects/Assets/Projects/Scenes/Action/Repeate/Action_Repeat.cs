using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Repeat : Action_Mono
{
	[SerializeField] private Action_Effect m_effect;
	[SerializeField] public bool m_action;

	// Start is called before the first frame update
	private void Start()
	{
		Debug.Log("Action_Repeate");
		Setup();
		m_type = GameManager._ACTION_TYPE.Repeate;
		ml_displayAnim.Add(transform.GetChild(2).GetComponent<Animator>());
		ResetValue();
	}
	protected override void ResetText()
	{
		string str = "      <size=80>" + (0) + "</size>\n    連打!!";
		ChangeCount(str);
	}

	// Update is called once per frame
	private void Update()
	{
		if (StartAction()) return;
		if (TimeCheck("Action_Repeate"))
		{
			InputRepeat();
			TimeDecrement();
		}
	}

	// 連打
	private void InputRepeat()
	{
		m_action = InputButtonDown();
		if (InputButtonDown() && m_time > 0f)
		{
			string str = "      <size=80>" + (++m_cnt) + "</size>\n    連打!!";
			ChangeCount(str);
			m_cutAnim.AnimSpeed(m_cnt, m_multiply);
			m_effect.GenerateEffects();
		}
		if (!InputButtonUp())
		{
		}
	}

	private bool InputButtonDown()
	{
		return (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"));
	}
	private bool InputButtonUp()
	{
		return (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"));
	}
}