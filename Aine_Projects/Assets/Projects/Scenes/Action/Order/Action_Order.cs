﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using MyBox;
using UnityEngine.Playables;
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
	[SerializeField] private GameObject m_newComment;
	[SerializeField] private Action_Effect m_effect;
	[SerializeField] private Action_Order_Data m_data;
	[SerializeField] private List<PadButton> ml_pad;
	[SerializeField] private List<PadButton> ml_key;

	private Transform m_circleP;
	private Transform m_button;
	private Transform m_comment4;
	private TextMeshProUGUI m_compSampText;
	private Transform m_cmtCanvas;

	[SerializeField] private int m_commnetCnt;
	[SerializeField] private int m_selectComment;
	private Animator m_orderAnim;
	private Transform m_actionCamera;
	[SerializeField] public static bool m_diffAct;

	private void Start()
	{
		//Debug.Log("Action_Order");
		Setup();
		m_type = GameManager._ACTION_TYPE.Order;
		m_circleP = transform.Find("_Order").Find("Order");
		m_button = m_circleP.GetChild(0);
		m_comment4 = m_circleP.GetChild(1);
		m_compSampText = m_circleP.Find("Text").Find("CompSamp").GetComponent<TextMeshProUGUI>();
		m_compSampText.text = "";
		m_cmtCanvas = GameObject.Find("Comment Canvas").GetComponent<Transform>();
		m_orderAnim = transform.Find("_Order").GetComponent<Animator>();
		ml_pad = new List<PadButton>();

		GameObject.Find("Stage Camera").GetComponent<PlayableDirector>().enabled = true;
		GameObject.Find("Stage Camera").GetComponent<PlayableDirector>().Play();
		m_actionCamera = GameObject.Find("Action_Camera").GetComponent<Transform>();
		for (int i = 0; i < 7; i++)
			m_actionCamera.GetChild(i).gameObject.SetActive(true);

		SaveValue(m_data.m_list, ref m_data.m_listCopy);

		RandomText();
		ResetValue();

		// 演出開始
		StartCoroutine(StartEffect());
	}
	
	// Update is called once per frame
	private void Update()
	{
		m_actionCamera.transform.position = GameObject.Find("Idol").transform.position;
		if (m_bEffect) return;
		if (Input.GetKeyDown(KeyCode.R))
			RandomText();

		if (TimeCheck("Action_Order"))
		{
			switch (m_diffAct)
			{
				case true:  // second
					if (m_commnetCnt < 4) InputDelayComment_Second();
					break;
				case false: // first
					if (m_commnetCnt < 4) InputDelayComment_First();
					break;
			}
			TimeDecrement();
		}
	}
	private void SaveValue(List<Action_Order_Data.Param> source, ref List<Action_Order_Data.Param> copy)
	{
		copy = new List<Action_Order_Data.Param>();
		for (int i = 0; i < m_data.m_list.Count; i++)
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
		SaveValue(m_data.m_list, ref m_data.m_listCopy);
		m_selectComment = UnityEngine.Random.Range(0, m_data.m_listCopy.Count);
		m_compSampText.text = "";
		m_enterText = 0;
		m_delay = false;

		for (int i = 0; i < 8; i++)
		{
			if(i % 2 == 0)
				m_button.GetChild(i).GetComponent<Image>().enabled = true;
			if (i % 2 == 1)
				m_button.GetChild(i).GetComponent<Image>().enabled = false;
		}
		for (int i = 0; i < 4; i++) m_enterTextB[i] = false;
		m_circleP.Find("Text").Find("Comp").GetComponent<TextMeshProUGUI>().text =
					"<color=#ffffff>" + m_data.m_listCopy[m_selectComment].text + "</color>";
		List<Action_Order_Data.Char> work = m_data.m_listCopy[m_selectComment].Moji;
		switch (m_diffAct)
		{
			case true:
				work = work.OrderBy(o => Guid.NewGuid()).ToList();
				for (int i = 0; i < 4; i++)
					m_data.m_listCopy[m_selectComment].Moji[i] = work[i];
				for (int i = 0; i < 4; i++)
					m_circleP.Find("Comment4").GetChild(i).GetComponent<TextMeshProUGUI>().text =
						m_data.m_listCopy[m_selectComment].Moji[i].text;
				break;
			case false:
				m_newMoji = new List<Action_Order_Data.Char>();
				Action_Order_Data.Char workMoji1 = new Action_Order_Data.Char();
				workMoji1.num = 0;
				workMoji1.text = m_data.m_listCopy[m_selectComment].Moji[0].text + m_data.m_listCopy[m_selectComment].Moji[1].text;
				m_newMoji.Add(workMoji1);
				Action_Order_Data.Char workMoji2 = new Action_Order_Data.Char();
				workMoji2.num = 1;
				workMoji2.text = m_data.m_listCopy[m_selectComment].Moji[2].text + m_data.m_listCopy[m_selectComment].Moji[3].text;
				m_newMoji.Add(workMoji2);

				m_newMoji = m_newMoji.OrderBy(o => Guid.NewGuid()).ToList();

				m_circleP.Find("Button").GetChild(2).GetComponent<Image>().color = new Color(.4f, .4f, .4f);
				m_circleP.Find("Button").GetChild(4).GetComponent<Image>().color = new Color(.4f, .4f, .4f);
				m_circleP.Find("Comment4").GetChild(0).gameObject.SetActive(false);
				m_circleP.Find("Comment4").GetChild(3).gameObject.SetActive(false);
				m_circleP.Find("Comment4").GetChild(2).GetComponent<TextMeshProUGUI>().text = m_newMoji[0].text;
				m_circleP.Find("Comment4").GetChild(1).GetComponent<TextMeshProUGUI>().text = m_newMoji[1].text;
				break;
		}
	}
	private int m_enterText;
	private bool[] m_enterTextB = new bool[4];
	private bool m_delay;
	[SerializeField] private float m_delayTime;
	[SerializeField] private List<Action_Order_Data.Char> m_newMoji;
	private IEnumerator Delay()
	{
		m_delay = true;
		yield return new WaitForSeconds(m_delayTime);
		m_delay = false;
	}
	private void InputDelayComment_First()
	{
		if (m_delay) return;

		//	A
		if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 2")) && !m_enterTextB[1])
		{
			if (m_commnetCnt == m_newMoji[0].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[1] = true;
				m_button.GetChild(0).GetComponent<Image>().enabled = false;
				m_button.GetChild(1).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(2).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		//	D
		if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown("joystick button 1")) && !m_enterTextB[3])
		{
			if (m_commnetCnt == m_newMoji[1].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[3] = true;
				m_button.GetChild(6).GetComponent<Image>().enabled = false;
				m_button.GetChild(7).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(1).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(1).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		switch (m_enterText)
		{
			case 0:
				m_compSampText.text = m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 1:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text + "</color>" +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 2:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text+
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text + "</color>";
				break;
		}
		if (m_commnetCnt >= 2)
		{
			m_commnetCnt = 0;
			StartCoroutine(InstanceComment(m_compSampText.text));
			StartCoroutine(NextText());
		}
	}
	private void InputDelayComment_Second()
	{
		if (m_delay) return;
		//	W
		if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("joystick button 3")) && !m_enterTextB[0])
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[3].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[0] = true;
				m_button.GetChild(2).GetComponent<Image>().enabled = false;
				m_button.GetChild(3).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(3).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(3).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		//	A
		if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 2")) && !m_enterTextB[1])
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[2].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[1] = true;
				m_button.GetChild(0).GetComponent<Image>().enabled = false;
				m_button.GetChild(1).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(2).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		//	S
		if ((Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown("joystick button 0")) && !m_enterTextB[2])
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[0].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[2] = true;
				m_button.GetChild(4).GetComponent<Image>().enabled = false;
				m_button.GetChild(5).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(0).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		//	D
		if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown("joystick button 1")) && !m_enterTextB[3])
		{
			if (m_commnetCnt == m_data.m_listCopy[m_selectComment].Moji[1].num)
			{
				m_soundSorce.PlayOneShot(m_sound[0]);
				m_commnetCnt++;
				m_cnt++;
				m_enterText = m_commnetCnt;
				m_enterTextB[3] = true;
				m_button.GetChild(6).GetComponent<Image>().enabled = false;
				m_button.GetChild(7).GetComponent<Image>().enabled = true;
				m_comment4.GetChild(1).GetComponent<TextMeshProUGUI>().text = "<color=#8A8A8A>" + m_comment4.GetChild(1).GetComponent<TextMeshProUGUI>().text + "</color>";
			}
			else
				StartCoroutine(Delay());
		}
		switch (m_enterText)
		{
			case 0:
				m_compSampText.text = m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 1:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text + "</color>" +
															m_data.m_list[m_selectComment].Moji[1].text +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 2:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text + "</color>" +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 3:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text +
															m_data.m_list[m_selectComment].Moji[2].text + "</color>" +
															m_data.m_list[m_selectComment].Moji[3].text;
				break;
			case 4:
				m_compSampText.text = "<color=#000000>" + m_data.m_list[m_selectComment].Moji[0].text +
															m_data.m_list[m_selectComment].Moji[1].text +
															m_data.m_list[m_selectComment].Moji[2].text +
															m_data.m_list[m_selectComment].Moji[3].text + "</color>";
				break;
		}
		if (m_commnetCnt >= 4)
		{
			StartCoroutine(InstanceComment(m_compSampText.text));
			StartCoroutine(NextText());
		}
	}

	private IEnumerator InstanceComment(string text)
	{
		yield return new WaitForSeconds(1f);

		m_data.m_listCopy.RemoveAt(m_selectComment);
		GameObject work = Instantiate(m_newComment, m_cmtCanvas);
		work.GetComponent<RectTransform>().localPosition = new Vector2(0f, UnityEngine.Random.Range(.2f, 6f));
		work.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
	}
	private IEnumerator NextText()
	{
		yield return new WaitForSeconds(1f);
		RandomText();
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
		m_startAnim.Play("StartText");
		//m_orderAnim.Play("StartButton");
		m_timeAnim.Play("Order_Start");
		yield return new WaitForSeconds(m_startWaitTime);
		//m_cutAnim.AnimSpeed(0, m_multiply);
		//m_cutin.PlayAnim(true);
		m_bEffect = false;
	}

	// 終了演出
	protected override IEnumerator EndEffect(string name)
	{
		Debug.Log("END");
		enabled = false;
		yield return new WaitForSeconds(m_stopTime);
		ChackEvaluation((int)m_cnt);
		m_ghost.GenerateGhost(m_ev);
		m_manager.AddMaster(m_type, (int)m_cnt, m_ev);
		m_startAnim.Play("EndText");
		m_orderAnim.Play("EndButton");
		m_timeAnim.Play("Time_End");
		//m_cutin.PlayAnim(false);
		yield return new WaitForSeconds(2f);
		m_evaAnim.SetBool("Start", false);
		yield return new WaitForSeconds(1f);
		ResetValue();
		ResetText();
		for (int i = 0; i < 7; i++)
			m_actionCamera.GetChild(i).gameObject.SetActive(true);
		GameObject.Find("Stage Camera").GetComponent<PlayableDirector>().enabled = false;
		StartCoroutine(m_scr.imageShot());
		m_manager.m_controll = m_oldCtrl;
		m_manager.ChangeControll();
		// アンロード
		SceneManager.UnloadSceneAsync(name);
	}
}