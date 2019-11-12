using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class Action_Timing : Action_Mono
{
	[Header("[Child...]")]
	[SerializeField] private TextMeshProUGUI m_timingOut;
	[SerializeField] private TextMeshProUGUI m_timingIn;
	[SerializeField] private TextMeshProUGUI m_EvText;
	[SerializeField] private float m_maxSize;
	[SerializeField] private float m_minSize;
	[SerializeField] private float m_exBad;
	[SerializeField][Range(0f, 1f)] private float m_lerpTime;
	[SerializeField] private float m_multy;
	[SerializeField] private bool m_down;
	[SerializeField] private bool m_up;
	[SerializeField] private float m_sizeUp;
	// Start is called before the first frame update
	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Timing;
		ResetValue();
		m_lerpTime = 0f;
		m_down = false; m_up = false;
		//enabled = false;
	}
	private void OnDisable()
	{
		m_lerpTime = 0f;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			m_lerpTime = 0f;
		}
		if (Input.GetMouseButton(0) && m_up == false)
		{
			m_lerpTime -= Time.deltaTime * m_multy;
			m_down = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			m_up = true;
			CheckEvalution();
		}

		//if(Input.GetMouseButtonUp(0))
		//{
		//	CheckEvalution();
		//}
		if (m_lerpTime <= 0f) m_lerpTime = 0f;
		else if (m_lerpTime >= 1f) m_lerpTime = 1f;

		if (m_down == true && m_up == false)
			LerpSize();
		if (m_down == true && m_up == true)
		{
			if (m_timingOut.fontSize >= 600f)
			{
				m_up = m_down = false;
				m_lerpTime = 0f;
				LerpSize(0f);
			}
			m_timingOut.fontSize += Time.deltaTime * m_sizeUp;
		}


	}
	private void LerpSize()
	{
		m_timingOut.fontSize = Mathf.Lerp(m_maxSize, m_minSize, m_lerpTime);
	}
	private void LerpSize(float time)
	{
		m_timingOut.fontSize = Mathf.Lerp(m_maxSize, m_minSize, time);
	}
	private void CheckEvalution()
	{
		if (m_lerpTime < m_nice)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_EvText.text = m_ev.ToString();
		}
		else if (m_lerpTime < m_good)
		{
			m_ev = GameManager._Evaluation.Good;
			m_EvText.text = m_ev.ToString();
		}
		else if (m_lerpTime > m_exBad)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_EvText.text = m_ev.ToString();
		}
		else if (m_lerpTime < m_excellent)
		{
			m_ev = GameManager._Evaluation.Excellent;
			m_EvText.text = m_ev.ToString();
		}
	}
}