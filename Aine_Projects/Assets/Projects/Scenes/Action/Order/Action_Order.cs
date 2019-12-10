using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using System.Linq;
using MyBox;

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
		m_sampleText = m_circle.GetChild(3).GetComponent<TextMeshProUGUI>();
		m_sampleText.text = "";
		Debug.Log("Action_Order");
		ml_pad = new List<PadButton>();

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
		
		InputOrderText();
		//if (TimeCheck("Action_Order"))
		//{
		//	RandomButton();
		//	InputOrder();
		//	TimeDecrement();
		//}
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
		SaveValue(ref m_data.m_list, ref m_data.m_listCopy);
		m_selectComment = UnityEngine.Random.Range(0, m_data.m_listCopy.Count);
		m_sampleText.text = "";
		m_circle.GetChild(2).GetComponent<TextMeshProUGUI>().text =
					m_data.m_listCopy[m_selectComment].Moji[0].text +
					m_data.m_listCopy[m_selectComment].Moji[1].text +
					m_data.m_listCopy[m_selectComment].Moji[2].text +
					m_data.m_listCopy[m_selectComment].Moji[3].text;
		List<Action_Order_Data.Char> work = m_data.m_listCopy[m_selectComment].Moji;
		work = work.OrderBy(o => Guid.NewGuid()).ToList();
		for(int i = 0; i < 4; i++)
			m_data.m_listCopy[m_selectComment].Moji[i] = work[i];
		for (int i = 0; i < 4; i++)
			m_circle.GetChild(1).GetChild(i).GetComponent<TextMeshProUGUI>().text = m_data.m_listCopy[m_selectComment].Moji[i].text;

		//m_circle.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = m_data.m_list[m_selectComment].text[0];
		//m_circle.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = m_data.m_list[m_selectComment].text[1];
		//m_circle.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = m_data.m_list[m_selectComment].text[2];
		//m_circle.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text = m_data.m_list[m_selectComment].text[3];

	}

	private void InputOrderText()
	{
		//switch (m_manager.m_controll)
		//{
		//	case GameManager._ControllType.Mouse:
		//		//	W
		//		if (Input.GetKeyDown(KeyCode.W))
		//		{
		//			m_sampleText.text += m_data.m_list[m_selectComment].text[0];
		//		}
		//		//	A
		//		if (Input.GetKeyDown(KeyCode.A))
		//		{
		//			m_sampleText.text += m_data.m_list[m_selectComment].text[1]; ;
		//		}
		//		//	S
		//		if (Input.GetKeyDown(KeyCode.S))
		//		{
		//			m_sampleText.text += m_data.m_list[m_selectComment].text[2]; ;
		//		}
		//		//	D
		//		if (Input.GetKeyDown(KeyCode.D))
		//		{
		//			m_sampleText.text += m_data.m_list[m_selectComment].text[3]; ;
		//		}
		//		break;
		//	case GameManager._ControllType.GamePad:
		//		break;
		//}
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
}