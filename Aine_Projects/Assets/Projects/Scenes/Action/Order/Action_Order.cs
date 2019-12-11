﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using System.Linq;
using MyBox;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder (1)]
public class Action_Order : Action_MonoSamp
{
	public enum PadButton
	{
		A,
		B,
		X,
		Y,
	}
	public enum KeyButton
	{
		W,
		A,
		S,
		D,
	}
	[Header("[Child...]")]
	[SerializeField] private Action_Effect m_effect;
	[SerializeField] private TextMeshProUGUI m_order;
	[SerializeField] private Action_Order_Data m_data;
	[SerializeField] private List<PadButton> ml_pad;
	[SerializeField] private List<KeyButton> ml_key;
	private Transform m_circle;
	private TextMeshProUGUI m_sampleText;
	[SerializeField] private int m_selectComment;
	[SerializeField] private int m_commnetCnt;

	private void Awake()
	{
	}
	// Start is called before the first frame update
	private void Start()
	{
		Setup();
		m_type = GameManager._ACTION_TYPE.Order;
		ml_displayAnim.Add(transform.GetChild(2).GetComponent<Animator>());
		m_order = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
		m_circle = transform.GetChild(2).GetChild(2);
		m_sampleText = m_circle.GetChild(4).GetComponent<TextMeshProUGUI>();
		m_sampleText.text = "";
		Debug.Log("Action_Order");
		ml_pad = new List<PadButton>();
		m_commnetCnt = 0;
		SaveValue(ref m_data.m_list, ref m_data.m_listCopy);
		RandomButton();
		RandomText();
		//ResetValue();
		// 演出開始
		//StartCoroutine(StartEffect());
	}
	protected override void ResetText()
	{
		string str = "      <size=80>" + (0) + "</size>\n    連打!!";
		ChangeCount(str);
	}

	// Update is called once per frame
	private void Update()
	{
		//if (m_bEffect) return;
		if (Input.GetKeyDown(KeyCode.R))
			RandomText();
		
		//if(m_commnetCnt < 4)
		//	InputOrderText();
		//if (TimeCheck("Action_Order"))
		{
			//	RandomButton();
			//	InputOrder();
			if (m_commnetCnt < 4)
				InputOrderText();
			//TimeDecrement();
		}
	}
	private void SaveValue(ref List<Action_Order_Data.Param> source, ref List<Action_Order_Data.Param> copy)
	{
		copy = new List<Action_Order_Data.Param>();
		for(int i = 0; i < m_data.m_list.Count; i ++)
		{
			//Action_Order_Data.Param copyParam;// = new List<Action_Order_Data.Param>();
			List<Action_Order_Data.Char> copyChar = new List<Action_Order_Data.Char>();
			for (int j = 0; j < 4; j++)
			{
				Action_Order_Data.Char work;
				work.text = source[i].Moji[j].text;
				work.num = j;
				copyChar.Add(work);
			}
			Action_Order_Data.Param param;
			param.Moji = copyChar;
			param.text = param.Moji[0].text + param.Moji[1].text + param.Moji[2].text + param.Moji[3].text;
			copy.Add(param);
		}
	}
	private void RandomText()
	{
		m_commnetCnt = 0;
		SaveValue(ref m_data.m_list, ref m_data.m_listCopy);
		m_selectComment = UnityEngine.Random.Range(0, m_data.m_listCopy.Count);
		m_sampleText.text = "";
		m_circle.GetChild(3).GetComponent<TextMeshProUGUI>().text =
					m_data.m_listCopy[m_selectComment].text;
		List<Action_Order_Data.Char> work = m_data.m_listCopy[m_selectComment].Moji;
		work = work.OrderBy(o => Guid.NewGuid()).ToList();
		for(int i = 0; i < 4; i++)
			m_data.m_listCopy[m_selectComment].Moji[i] = work[i];
		for (int i = 0; i < 4; i++)
			m_circle.GetChild(1).GetChild(i).GetComponent<TextMeshProUGUI>().text = m_data.m_listCopy[m_selectComment].Moji[i].text;
	}
	/*
	 //*  1. 失敗時コメント削除、次のコメに移行
	 //*  2. 初期案　　コメントごとにポイント打ったら絶対完成
	 *  3. 間違えたコメントを流す or 失敗用コメント
	 *  4. 間違えた場合の判定なくす　Delayをつける
	 */
	private void InputMissComment()
	{
		//	W
		if (Input.GetKeyDown(KeyCode.W))
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[3].num)
			{
				m_commnetCnt++;
				m_sampleText.text += m_data.m_listCopy[m_selectComment].Moji[3].text;
				Debug.Log("Succes");
			}
			else
			{
				StartCoroutine(NextText());
				Debug.Log("false");
			}
		}
		//	A
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[2].num)
			{
				m_commnetCnt++;
				m_sampleText.text += m_data.m_listCopy[m_selectComment].Moji[2].text;
				Debug.Log("Succes");
			}
			else
			{
				StartCoroutine(NextText());
				Debug.Log("false");
			}
		}
		//	S
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[0].num)
			{
				m_commnetCnt++;
				m_sampleText.text += m_data.m_listCopy[m_selectComment].Moji[0].text;
				Debug.Log("Succes");
			}
			else
			{
				StartCoroutine(NextText());
				Debug.Log("false");
			}
		}
		//	D
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[1].num)
			{
				m_commnetCnt++;
				m_sampleText.text += m_data.m_listCopy[m_selectComment].Moji[1].text;
				Debug.Log("Succes");
			}
			else
			{
				StartCoroutine(NextText());
				Debug.Log("false");
			}
		}
	}
	private void InputOrderText()
	{
		switch (m_manager.m_controll)
		{
			case GameManager._ControllType.Auto:
				//	W
				if (Input.GetKeyDown(KeyCode.W))
				{
					if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[3].num)
					{
						m_commnetCnt++;
						m_sampleText.text += "<color=#000000>" + m_data.m_listCopy[m_selectComment].Moji[3].text + "</color>";
						Debug.Log("Succes");
					}
					else
					{
						StartCoroutine(NextText());
						Debug.Log("false");
					}
				}
				//	A
				if (Input.GetKeyDown(KeyCode.A))
				{
					if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[2].num)
					{
						m_commnetCnt++;
						m_sampleText.text += "<color=#000000>" + m_data.m_listCopy[m_selectComment].Moji[2].text + "</color>";
						Debug.Log("Succes");
					}
					else
					{
						StartCoroutine(NextText());
						Debug.Log("false");
					}
				}
				//	S
				if (Input.GetKeyDown(KeyCode.S))
				{
					if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[0].num)
					{
						m_commnetCnt++;
						m_sampleText.text += "<color=#000000>" + m_data.m_listCopy[m_selectComment].Moji[0].text + "</color>";
						Debug.Log("Succes");
					}
					else
					{
						StartCoroutine(NextText());
						Debug.Log("false");
					}
				}
				//	D
				if (Input.GetKeyDown(KeyCode.D))
				{
					if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[1].num)
					{
						m_commnetCnt++;
						m_sampleText.text += "<color=#000000>" + m_data.m_listCopy[m_selectComment].Moji[1].text + "</color>";
						Debug.Log("Succes");
					}
					else
					{
						StartCoroutine(NextText());
						Debug.Log("false");
					}
				}
				break;
			case GameManager._ControllType.GamePad:
				break;
		}
		if (m_commnetCnt >= 4)
			StartCoroutine(NextText());
	}
	//private IEnumerator 
	private IEnumerator NextText()
	{
		yield return new WaitForSeconds(1f);
		RandomText();
	}

	private void RandomButton()
	{
		if (ml_pad.Count < 4)
		{
			ml_pad.Add((PadButton)UnityEngine.Random.Range(0, 3));
			if (ml_pad.Count == 4)
				NextOrder();
			RandomButton();
		}
	}
	// 
	private void NextOrder()
	{
		m_order.text = "<size=100><color=yellow>" + ml_pad[0].ToString() + "</color></size>"
							+ " " + ml_pad[1].ToString()
							+ " " + ml_pad[2].ToString()
							+ " " + ml_pad[3].ToString();
	}

	// 順番
	private void InputOrder()
	{
		if (InputButton())
		{
			string str = "      <size=80>" + (++m_cnt) + "</size>\n    連打!!";
			ChangeCount(str);
		}
	}
	private bool InputButton()
	{
		if (Input.GetKeyDown("joystick button " + (int)ml_pad[0]) || Input.GetKeyDown(KeyCode.Space))
		{
			ml_pad.RemoveAt(0);
			m_effect.GenerateEffects();
			return true;
		}
		return false;
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
		//m_buttonAnim.Play("StartButton");
		//m_countAnim.Play("StartCount");
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
		//m_buttonAnim.Play("EndButton");
		//m_countAnim.Play("EndCount");
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