using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyBox;
using TMPro;

public class Action_MonoSamp : MonoBehaviour
{
	[Header("[Parent...]")]
	// Global
	protected GameManager m_manager;
	[ReadOnly] [SerializeField] protected GameManager._ACTION_TYPE m_type;
	/*[ReadOnly] */[SerializeField] protected bool m_bEffect;

	// Time
	[SerializeField] protected float m_defTime;             // アクション時間
	[ReadOnly] [SerializeField] protected float m_time;     // 経過時間
	[ReadOnly] [SerializeField] protected int m_cnt;

	// Animator
	[SerializeField] protected Transform m_common;
	[SerializeField] protected Animator m_startAnim;
	[SerializeField] protected Animator m_cntAnim;
	[SerializeField] protected Animator m_timeAnim;
	[SerializeField] protected Animator m_evaAnim;
	[SerializeField] protected List<Animator> ml_displayAnim;

	[Separator]     // Text
	[SerializeField] protected TextMeshProUGUI m_timeText;
	[SerializeField] protected TextMeshProUGUI m_cntText;
	[SerializeField] protected TextMeshProUGUI m_evaText;

	// CutIn
	[SerializeField] protected float m_multiply;
	protected CutIN_Manager m_cutin;
	[SerializeField] protected Animator_Controller m_cutAnim;

	[Separator]
	[SerializeField] protected float m_startWaitTime;     // カウント開始待ち
	[SerializeField] private float m_displayWaitTime;   // UI消去開始待ち
	[SerializeField] protected float m_stopTime;

	[Separator]     // 評価
	[SerializeField] protected GameManager._Evaluation m_ev;
	[SerializeField] protected float m_excellent;
	[SerializeField] protected float m_good;
	[SerializeField] protected float m_nice;

	protected ScreenShot m_scr;
	[SerializeField] protected GameManager._ControllType m_oldCtrl;

	// Component
	protected void Setup()
	{
		// GameManager
		m_manager = GameObject.Find("GameManager").GetComponent<GameManager>();

		// Animator
		m_common = GameObject.Find("Action/Common").GetComponent<Transform>();
		m_startAnim = transform.GetChild(0).GetComponent<Animator>();
		m_cntAnim = transform.GetChild(1).GetComponent<Animator>();
		m_timeAnim = m_common.GetChild(0).GetComponent<Animator>();
		m_evaAnim = m_common.GetChild(1).GetComponent<Animator>();
		ml_displayAnim = new List<Animator>();
		ml_displayAnim.Add(transform.GetChild(1).GetComponent<Animator>());
		ml_displayAnim.Add(m_common.GetChild(0).GetComponent<Animator>());

		// Text
		m_timeText = m_common.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
		m_evaText = m_common.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
		m_cntText = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();

		// Cutin
		m_cutAnim = GameObject.Find("Mob_Unit").GetComponent<Animator_Controller>();
		m_cutin = GameObject.Find("CutIn").GetComponent<CutIN_Manager>();

		m_scr = GameObject.Find("Cam").GetComponent<ScreenShot>();
		m_oldCtrl = m_manager.m_controll;

		m_manager.m_controll = GameManager._ControllType.Auto;
		m_manager.ChangeControll();
	}

	// Reset
	protected virtual void ResetValue()
	{
		m_startAnim.SetBool("Start", false);
		m_cntAnim.SetBool("Start", false);
		m_timeAnim.SetBool("Start", false);
		m_evaAnim.SetBool("Start", false);
		m_cntAnim.SetBool("Start", false);
		AnimSet(false);
		m_time = m_defTime;
		ChangeTime();
		m_cnt = 0;
		m_bEffect = true;
	}

	// 開始演出
	protected virtual IEnumerator StartEffect()
	{
		yield return null;
		m_startAnim.SetBool("Start", true);
		StartCoroutine(DisplayCnt());
		yield return new WaitForSeconds(m_startWaitTime);
		m_cutAnim.AnimSpeed(0, m_multiply);
		m_cutin.PlayAnim(true);
		m_bEffect = false;
	}

	private IEnumerator DisplayCnt()
	{
		yield return new WaitForSeconds(m_displayWaitTime);
		AnimSet(true);
	}

	// 時間チェック
	protected virtual bool TimeCheck(string name)
	{
		if(m_time <= 0f)
		{
			m_time = 0f;
			ChangeTime();
			StartCoroutine(EndEffect(name));
			return false;
		}
		return true;
	}

	// 終了演出
	protected virtual IEnumerator EndEffect(string name)
	{
		enabled = false;
		yield return new WaitForSeconds(m_stopTime);
		ChackEvaluation(m_cnt);
		m_manager.AddMaster(m_type, m_cnt, m_ev);
		m_startAnim.SetBool("Start", false);
		m_cutin.PlayAnim(false);
		yield return new WaitForSeconds(2f);
		AnimSet(false);
		m_evaAnim.SetBool("Start", false);
		yield return new WaitForSeconds(1f);
		ResetValue();
		ResetText();
		StartCoroutine(m_scr.imageShot());
		// アンロード
		SceneManager.UnloadSceneAsync(name);
	}
	// Anim設定
	protected void AnimSet(bool isBool)
	{
		foreach (Animator anim in ml_displayAnim)
		{
			anim.SetBool("Start", isBool);
		}
	}

	// 判定
	protected void ChackEvaluation(int num)
	{
		// excellent
		if (num >= m_excellent)
		{
			m_ev = GameManager._Evaluation.Excellent;
			m_evaText.text = m_ev.ToString() + "!!";
		}
		// Good
		else if (num >= m_good)
		{
			m_ev = GameManager._Evaluation.Good;
			m_evaText.text = m_ev.ToString() + "!";
		}
		else if (num == 0)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = "??(^q^)??";
		}
		// Nice
		else if (num <= m_nice)
		{
			m_ev = GameManager._Evaluation.Nice;
			m_evaText.text = m_ev.ToString();
		}
		m_evaAnim.SetBool("Start", true);
	}
	// 時間更新
	protected void TimeDecrement()
	{
		ChangeTime();
		m_time -= Time.deltaTime;
	}
	// 時間表示更新
	protected void ChangeTime()
	{
		m_timeText.text = "のこり : <size=50> " + m_time.ToString("f2") + "</size> 秒";
	}
	// カウント表示更新
	protected void ChangeCount(string str)
	{
		m_cntText.text = str;
	}
	// テキスト初期化
	protected virtual void ResetText()
	{
		Debug.Log("NoneReset");
	}
}