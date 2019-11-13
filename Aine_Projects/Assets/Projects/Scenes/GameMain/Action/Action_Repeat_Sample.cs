using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

namespace Sample
{
	public class Action_Repeat_Sample : Action_Mono
	{
		// Global
		//private GameManager m_manager;
		//[SerializeField] public bool m_actRepeat;
		//[ReadOnly] [SerializeField] private bool m_isInput;
		//private bool m_input;

		// 
		//[SerializeField] private float m_defTime;
		//[ReadOnly] [SerializeField] private float m_time;
		//[Header ("[Child...]")]
		//[ReadOnly] [SerializeField] private int m_cnt;
		//[ReadOnly] [SerializeField] private bool m_start;
		//private bool m_setEffect;                           // 演出中

		//[Separator]
		//[SerializeField] private float m_startWaitTime;     // カウント開始待ち
		//[SerializeField] private float m_displayWaitTime;   // UI消去開始待ち
		//[SerializeField] private float m_stopTime;

		//[Separator]     // Text
		//[SerializeField] private TextMeshProUGUI m_timeMesh;
		//[SerializeField] private TextMeshProUGUI m_cntMesh;
		//[SerializeField] private TextMeshProUGUI m_evaText;


		//[Separator]     // Animator
		//[SerializeField] private Transform m_common;
		//private Animator m_startAnim;
		//private Animator m_evatAnim;
		//private Animator[] m_actAnim;
		//private Animator m_evaAnim;

		// CutIn
		//[SerializeField] private float m_multiply;
		//private CutIN_Manager m_cutin;
		//private Animator_Controller m_cutAnim;

		//[Separator]     // 評価
		//[SerializeField] private GameManager._Evaluation m_ev;
		//[SerializeField] private int m_excellent;
		//[SerializeField] private int m_good;
		//[SerializeField] private int m_nice;

		// Start is called before the first frame update
		private void Start()
		{
			Setup();
			m_type = GameManager._ACTION_TYPE.Repeate;
			//m_manager = GameObject.Find("GameManager").GetComponent<GameManager>();

			// Animator
			//m_startAnim = transform.GetChild(0).GetComponent<Animator>();
			//m_evaAnim = m_common.GetChild(0).GetComponent<Animator>();
			//m_actAnim = new Animator[2];
			//m_actAnim[0] = transform.GetChild(1).GetComponent<Animator>();
			//m_actAnim[1] = m_common.GetChild(1).GetComponent<Animator>();
			// Cutin
			//m_cutAnim = GameObject.Find("Mob_Unit").GetComponent<Animator_Controller>();
			//m_cutin = GameObject.Find("CutIn").GetComponent<CutIN_Manager>();

			//ResetValue();
		}
		//private void ResetValue()
		//{
		//	m_setEffect = false;
		//	m_evaAnim.SetBool("Start", false);
		//	m_startAnim.SetBool("Start", false);
		//	//m_actAnim[0].SetBool("Start", false);
		//	//m_actAnim[1].SetBool("Start", false);
		//	m_cntAnim.SetBool("Start", false);
		//	m_timeAnim.SetBool("Start", false);
		//	m_time = m_defTime;
		//	m_start = false;
		//	ChangeTime();
		//	ChangeCount(m_cnt = 0);
		//}

		// Update is called once per frame
		private void Update()
		{
			if (StartAction()) return;
			if (TimeCheck())
			{
				InputRepeat();
				TimeDecrement();
			}
		}

		//private bool StartRepeat()
		//{
		//	if (Input.GetKeyDown(KeyCode.F1))
		//		m_isInput = !m_isInput;
		//	if (m_isInput)
		//		m_input = (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"));

		//	if (!m_start)
		//	{
		//		if ((m_input || m_actRepeat) && m_time > 0f && !m_setEffect)
		//		{
		//			StartCoroutine(StartEffect());
		//			Debug.Log("Start!");
		//		}
		//		return true;
		//	}
		//	else
		//		return false;
		//}
		private void InputRepeat()
		{
			if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && m_time > 0f)
			{
				string str = "      <size=80>" + (++m_cnt) + "</size>\n    連打!!";
				ChangeCount(str);
				m_cutAnim.AnimSpeed(m_cnt, m_multiply);
			}
		}
		//private IEnumerator StartEffect()
		//{
		//	m_setEffect = true;
		//	m_startAnim.SetBool("Start", true);
		//	StartCoroutine(DisplayCnt());
		//	yield return new WaitForSeconds(m_startWaitTime);
		//	m_actRepeat = false;
		//	m_cutAnim.AnimSpeed(0, m_multiply);
		//	m_cutin.PlayAnim(true);
		//	m_start = true;
		//}
		//private IEnumerator DisplayCnt()
		//{
		//	yield return new WaitForSeconds(m_displayWaitTime);
		//	m_timeAnim.SetBool("Start", true);
		//	m_cntAnim.SetBool("Start", true);
		//}

		//private bool TimeCheck()
		//{
		//	if (m_time <= 0f)
		//	{
		//		m_start = false;
		//		m_time = 0f;
		//		ChangeTime();
		//		StartCoroutine(StopInertia());
		//		return false;
		//	}

		//	return true;
		//}
		//private IEnumerator StopInertia()
		//{
		//	yield return new WaitForSeconds(m_stopTime);
		//	ChackEvaluation(m_cnt);
		//	m_manager.AddMaster(GameManager._ACTION_TYPE.Repeate, m_ev);
		//	m_manager.GetComponent<Ghost_Controller>().GenerateGhost(m_ev);
		//	m_startAnim.SetBool("Start", false);
		//	m_cutin.PlayAnim(false);
		//	yield return new WaitForSeconds(2f);
		//	m_timeAnim.SetBool("Start", false);
		//	m_cntAnim.SetBool("Start", false);
		//	m_evaAnim.SetBool("Start", false);
		//	//m_cutAnim.AnimSpeed(1, 1);
		//	yield return new WaitForSeconds(1f);
		//	ResetValue();
		//}

		//private void TimeDecrement()
		//{
		//	ChangeTime();
		//	m_time -= Time.deltaTime;
		//}
		//private void ChangeTime()
		//{
		//	m_timeMesh.text = "のこり : <size=50> " + m_time.ToString("f2") + "</size> 秒";
		//}
		//private void ChangeCount(string str)
		//{
		//	m_cntMesh.text = str;
		//}
		//private void ChackEvaluation()
		//{
		//	// excellent
		//	if (m_cnt >= m_excellent)
		//	{
		//		m_ev = GameManager._Evaluation.Excellent;
		//		m_evaText.text = m_ev.ToString() + "!!";
		//	}
		//	// Good
		//	else if (m_cnt >= m_good)
		//	{
		//		m_ev = GameManager._Evaluation.Good;
		//		m_evaText.text = m_ev.ToString() + "!";
		//	}
		//	else if (m_cnt == 0)
		//	{
		//		m_ev = GameManager._Evaluation.Nice;
		//		m_evaText.text = "??(^q^)??";
		//	}
		//	// Nice
		//	else if (m_cnt <= m_nice)
		//	{
		//		m_ev = GameManager._Evaluation.Nice;
		//		m_evaText.text = m_ev.ToString();
		//	}
		//	m_evaAnim.SetBool("Start", true);
		//}
	}
}