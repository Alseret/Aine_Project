using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Timing : Action_Mono
{
	public enum PadButton
	{
		A,
		B,
		X,
		Y,
	}
	[Header("[Child...]")]
	[SerializeField] private TextMeshProUGUI m_timingOut;
	[SerializeField] private TextMeshProUGUI m_timingIn;
	[SerializeField] private float m_maxSize;
	[SerializeField] private float m_minSize;
	[SerializeField] private PadButton m_pad;
	[SerializeField] [Range(0f, 1f)] private float m_lerpTime;
	private bool m_click;
	[SerializeField] private float m_multy;
	[SerializeField] private bool m_down;
	[SerializeField] private bool m_up;


	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Timing;
		ml_displayAnim.Add(transform.GetChild(2).GetComponent<Animator>());
		m_click = false;
		m_down = m_up = false;
		ResetValue();
		enabled = false;
	}
	private void OnDisable()
	{
		//ResetValue();
		m_click = false;
		m_lerpTime = 0f;
		LerpSize();
		m_down = m_up = false;
		m_time = m_defTime;
		m_pad = (PadButton)Random.Range(0, 3);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			OnDisable();
		if (StartAction()) return;

		if (!m_click && TimeisCheck())
			TimeDecrement();

		if ((Input.GetMouseButton(0) || Input.GetKey("joystick button " + (int)m_pad)) && !m_up)
		{
			m_click = true;
			m_down = true;
			m_lerpTime -= Time.deltaTime * m_multy;
			if (m_lerpTime <= 0f) m_lerpTime = 0f;
			else if (m_lerpTime >= 1f) m_lerpTime = 1f;
			m_timeAnim.SetBool("Start", false);
		}
		if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp("joystick button " + (int)m_pad)) && !m_up)
		{
			m_up = true;
			m_down = false;
		}

		if (m_down && !m_up)
			LerpSize();
		else if ((!m_down && m_up) && m_start)
		{
			
			CheckEvalution();
			StartCoroutine(StopInertiaA());
		}

	}
	private bool TimeisCheck()
	{
		if (m_time <= 0f)
		{
			m_start = false;
			m_time = 0f;
			ChangeTime();
			StartCoroutine(StopInertiaA());
			Debug.Log("入力してください!");
			return false;
		}
		return true;
	}
	private void LerpSize()
	{
		m_timingOut.fontSize = Mathf.Lerp(m_maxSize, m_minSize, m_lerpTime);
	}
	private IEnumerator StopInertiaA()
	{
		enabled = false;
		yield return new WaitForSeconds(m_stopTime);
		m_manager.AddMaster(m_type, m_cnt, m_ev);
		//m_manager.GetComponent<Ghost_Controller>().GenerateGhost(m_ev);
		m_startAnim.SetBool("Start", false);
		m_cutin.PlayAnim(false);
		yield return new WaitForSeconds(1f);
		AnimSet(false);
		m_evaAnim.SetBool("Start", false);
		yield return new WaitForSeconds(1f);
		ResetValue();
		m_start = false;
	}
	private void CheckEvalution()
	{
		if (m_lerpTime < m_nice)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = m_ev.ToString();
			//m_EvText.text = m_ev.ToString();
		}
		else if (m_lerpTime < m_good)
		{
			m_ev = GameManager._Evaluation.Good;
			m_evaText.text = m_ev.ToString() + "!";
			//m_EvText.text = m_ev.ToString();
		}
		else if (m_lerpTime < m_excellent)
		{
			m_ev = GameManager._Evaluation.Excellent;
			m_evaText.text = m_ev.ToString() + "!!";
			//m_EvText.text = m_ev.ToString();
		}
		else if(m_lerpTime <= 1f)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = m_ev.ToString();
			//m_EvText.text = m_ev.ToString();
		}
		m_evaAnim.SetBool("Start", true);
	}
}