using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

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
	[SerializeField] private List<PadButton> ml_pad;
	[SerializeField] private List<KeyButton> ml_key;

	// Start is called before the first frame update
	private void Start()
	{
		Debug.Log("Action_Order");
		Setup();
		m_type = GameManager._ACTION_TYPE.Order;
		ml_displayAnim.Add(transform.GetChild(2).GetComponent<Animator>());
		m_order = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
		ml_pad = new List<PadButton>();
		RandomButton();
		ResetValue();

		// 演出開始
		StartCoroutine(StartEffect());
	}
	protected override void ResetText()
	{
		string str = "      <size=80>" + (0) + "</size>\n    連打!!";
		ChangeCount(str);
	}

	// Update is called once per frame
	private void Update()
	{
		if (m_bEffect) return;

		if (TimeCheck("Action_Order"))
		{
			RandomButton();
			InputOrder();
			TimeDecrement();
		}
	}

	private void RandomButton()
	{
		if (ml_pad.Count < 4)
		{
			ml_pad.Add((PadButton)Random.Range(0, 3));
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