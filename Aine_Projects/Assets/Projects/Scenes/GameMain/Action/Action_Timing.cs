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
	[SerializeField] private float m_maxSize;
	[SerializeField] private float m_minSize;
	[SerializeField] private float m_lerpTime;
	[SerializeField] private float m_multy;

	// Start is called before the first frame update
	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Timing;
		ResetValue();
		m_lerpTime = 1f;
		//enabled = false;
	}
	private void OnDisable()
	{
		m_lerpTime = 1f;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			m_lerpTime = 1f;
		}
		if (Input.GetMouseButton(0))
		{
			m_lerpTime += Time.deltaTime * m_multy;
		}
		if(Input.GetMouseButtonUp(0))
		{
			Debug.Log(m_lerpTime);
		}
		if (m_lerpTime <= 0f) m_lerpTime = 0f;
		else if (m_lerpTime >= 1f) m_lerpTime = 1f;
		LerpSize();

	}
	private void LerpSize()
	{
		m_timingOut.fontSize = Mathf.Lerp(m_minSize, m_maxSize, m_lerpTime);
	}
}