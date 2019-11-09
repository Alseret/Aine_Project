using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyBox;

public class Action_Repeated : MonoBehaviour
{
	private GameManager m_manager;
	public bool m_actionRepeat;
	[SerializeField] private bool m_isInput;
	private bool m_input;
	[SerializeField] private float m_defaultTime;
	[ReadOnly][SerializeField] private float m_time;
	[ReadOnly][SerializeField] private int m_cnt;
	[ReadOnly][SerializeField] private bool m_start;
	//[SerializeField] private Text[] m_tTime;
	//[SerializeField] private Text[] m_tCnt;
	[SerializeField] private TextMeshProUGUI m_timeMesh;
	[SerializeField] private TextMeshProUGUI m_cntMesh;

	[Separator]
	[SerializeField] private float m_stopTime;
	[SerializeField] private float m_multiply;
	private CutIN_Manager m_cutin;
	private Animator_Controller m_cutAnim;
	
	[Separator]
	[SerializeField] private float m_startWaitTime;
	[SerializeField] private float m_displayWaitTime;
	private Animator m_startAnim;
	private Animator m_actionAnim;
	private bool m_setEffect;

	[Separator]
	[SerializeField] private GameManager._Evaluation m_ev;
	[SerializeField] private int m_excellent;
	[SerializeField] public int m_good;
	[SerializeField] private int m_nice;
	private TextMeshProUGUI m_evaText;
	private Animator m_evaAnim;

	private void Start()
	{
		m_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
		m_time = m_defaultTime;
		m_cutin = GameObject.Find("CutIn").GetComponent<CutIN_Manager>();
		m_cutAnim = GameObject.Find("Mob_Unit").GetComponent<Animator_Controller>();
		m_startAnim = transform.GetChild(0).GetComponent<Animator>();
		m_actionAnim = transform.GetChild(1).GetComponent<Animator>();
		m_evaText = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
		m_evaAnim = transform.GetChild(2).GetComponent<Animator>();
		ResetValue();
	}

	public void ResetValue()
	{
		m_setEffect = false;
		m_cutin.PlayAnim(false);
		m_startAnim.SetBool("Start", false);
		m_actionAnim.SetBool("Start", false);
		m_evaAnim.SetBool("Start", false);
		m_time = m_defaultTime;
		m_start = false;
		ChangeTime();
		ChangeCount(m_cnt = 0);
	}

	public void ResetParameter()
	{
		m_time = m_defaultTime;
		m_setEffect = false;
		m_start = false;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			ResetValue();
		if (StartRepeat()) return;
		if(TimeCheck())
		{
			InputRepeat();      // 入力
			TimeDecrement();    // 時間減らす
		}
	}
	public void SetTime(float time)
	{
		m_time = m_defaultTime = time;
	}
	private bool StartRepeat()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			m_isInput = !m_isInput;
		}
		if (m_isInput)
		{
			m_input = (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"));
		}
		if (!m_start)
		{	
			if ((m_input || m_actionRepeat) && m_time > 0f && !m_setEffect)
			{
				StartCoroutine(StartEffect());
				Debug.Log("Start!");
			}
			return true;
		}
		else
		{
			return false;
		}
	}
	private IEnumerator StartEffect()
	{
		m_setEffect = true;
		m_startAnim.SetBool("Start", true);
		StartCoroutine(DisplayCnt());
		yield return new WaitForSeconds(m_startWaitTime);
		m_actionRepeat = false;
		m_cutAnim.AnimSpeed(0, m_multiply);
		m_cutin.PlayAnim(true);
		m_start = true;
	}
	private IEnumerator DisplayCnt()
	{
		yield return new WaitForSeconds(m_displayWaitTime);
		m_actionAnim.SetBool("Start", true);
	}

	private void InputRepeat()
	{
		if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && m_time > 0f)
		{
			//Debug.Log("Increment");
			ChangeCount(++m_cnt);
			m_cutAnim.AnimSpeed(m_cnt, m_multiply);
		}
	}

	private bool TimeCheck()
	{
		if(m_time <= 0f)
		{
			m_start = false;
			m_time = 0f;
			ChangeTime();
			StartCoroutine(StopInertia());
			return false;
		}

		return true;
	}
	private IEnumerator StopInertia()
	{
		yield return new WaitForSeconds(m_stopTime);
		ChackEvaluation();
		m_manager.AddMaster(GameManager._ACTION_TYPE.Repeate, m_ev);
		m_manager.GetComponent<Ghost_Controller>().GenerateGhost(m_ev);
		m_startAnim.SetBool("Start", false);
		m_cutin.PlayAnim(false);
		yield return new WaitForSeconds(2f);
		m_actionAnim.SetBool("Start", false);
		m_evaAnim.SetBool("Start", false);
		//m_cutAnim.AnimSpeed(1, 1);
		yield return new WaitForSeconds(1f);
		ResetValue();
	}
	private void TimeDecrement()
	{
		ChangeTime();
		m_time -= Time.deltaTime;
	}
	private void ChangeTime()
	{
		//m_timeMesh.text = "Time : " + m_time.ToString("f2") + " s";
		m_timeMesh.text = "のこり : <size=50> " + m_time.ToString("f2") + "</size> 秒";
		//for (int i = 0; i < m_tTime.Length; i++)
		//	m_tTime[i].text = "Time : " + m_time.ToString("f2") + " s";
	}
	private void ChangeCount(int cnt)
	{
		//m_cntMesh.text = "Count : " + cnt;
		m_cntMesh.text = "      <size=80>" + cnt + "</size>\n    連打!!";
		//for (int i = 0; i < m_tTime.Length; i++)
		//	m_tCnt[i].text = "Count : " + cnt;
	}
	private void ChackEvaluation()
	{
		// excellent
		if (m_cnt >= m_excellent)
		{
			m_ev = GameManager._Evaluation.Excellent;
			m_evaText.text = m_ev.ToString() + "!!";
		}
		// Good
		else if (m_cnt >= m_good)
		{
			m_ev = GameManager._Evaluation.Good;
			m_evaText.text = m_ev.ToString() + "!";
		}
		else if (m_cnt == 0)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = "??(^q^)??";
		}
		// Nice
		else if (m_cnt <= m_nice)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = m_ev.ToString();
		}
		m_evaAnim.SetBool("Start", true);
	}
}