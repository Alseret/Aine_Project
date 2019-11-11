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

	// Start is called before the first frame update
	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Timing;
		ResetValue();
		enabled = false;
	}
	private void OnDisable()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		LerpSize();

	}
	private void LerpSize()
	{
		m_timingOut.fontSize = Mathf.Lerp(m_minSize, m_maxSize, m_lerpTime);
	}
}