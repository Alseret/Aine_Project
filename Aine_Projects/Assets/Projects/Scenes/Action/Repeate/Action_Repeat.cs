using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;
using UnityEngine.SceneManagement;

public class Action_Repeat : Action_MonoSamp
{
	[SerializeField] private Action_Effect m_effect;
	[ReadOnly] [SerializeField] public bool m_action;
	[SerializeField] private Animator m_buttonAnim;
	[SerializeField] private Animator m_countAnim;

	// Start is called before the first frame update
	private void Awake()
	{
		Setup();	// Component
		m_type = GameManager._ACTION_TYPE.Repeate;
		ml_displayAnim.Add(transform.GetChild(0).GetComponent<Animator>());
	}
	private void Start()
	{
		Debug.Log("Action_Repeate");
		ResetValue();
		// 演出開始
		StartCoroutine(StartEffect());
	}
	protected override void ResetText()
	{
		string str = "<size=80>0</size> Combo";
		ChangeCount(str);
	}
	// Reset
	protected override void ResetValue()
	{
		//m_startAnim.SetBool("Start", false);
		//m_cntAnim.SetBool("Start", false);
		//m_timeAnim.SetBool("Start", false);
		//m_evaAnim.SetBool("Start", false);
		//m_cntAnim.SetBool("Start", false);
		//AnimSet(false);
		m_time = m_defTime;
		ChangeTime();
		m_cnt = 0;
		m_bEffect = true;
	}

	// Update is called once per frame
	private void Update()
	{
		if (m_bEffect) return;
		if (TimeCheck("Action_Repeat"))
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
			string str = "<size=80>" + (++m_cnt) + "</size> Combo";
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


	// 時間チェック
	protected override bool TimeCheck(string name)
	{
		if (m_time <= 0f)
		{
			m_time = 0f;
			ChangeTime();
			StartCoroutine(EndEffect(name));
			return false;
		}
		return true;
	}

	// 開始演出
	protected override IEnumerator StartEffect()
	{
		//yield return null;
		m_startAnim.Play("StartText");
		m_buttonAnim.Play("StartButton");
		m_countAnim.Play("StartCount");
		m_timeAnim.SetBool("Start", true);
		yield return new WaitForSeconds(m_startWaitTime);
		m_cutAnim.AnimSpeed(0, m_multiply);
		m_cutin.PlayAnim(true);
		m_bEffect = false;
	}

	// 終了演出
	protected override IEnumerator EndEffect(string name)
	{
		Debug.Log("END");
		enabled = false;
		yield return new WaitForSeconds(m_stopTime);
		ChackEvaluation(m_cnt);
		m_manager.AddMaster(m_type, m_cnt, m_ev);
		m_startAnim.Play("EndText");
		m_buttonAnim.Play("EndButton");
		m_countAnim.Play("EndCount");
		m_timeAnim.SetBool("Start", false);
		m_cutin.PlayAnim(false);
		yield return new WaitForSeconds(2f);
		//AnimSet(false);
		m_evaAnim.SetBool("Start", false);
		yield return new WaitForSeconds(1f);
		ResetValue();
		ResetText();
		StartCoroutine(m_scr.imageShot());
		m_manager.m_controll = m_oldCtrl;
		m_manager.ChangeControll();
		// アンロード
		SceneManager.UnloadSceneAsync(name);
	}
}