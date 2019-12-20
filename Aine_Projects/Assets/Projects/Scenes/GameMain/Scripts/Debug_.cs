using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MyBox;

public class Debug_ : MonoBehaviour
{
	[ReadOnly] [SerializeField] private GameManager m_manager;
	[ReadOnly] [SerializeField] private Action_Nav m_nav;
	[SerializeField] private List<TextMeshProUGUI> m_debugText;

	[SerializeField] private bool isDebug = false;
	private GameManager._ControllType m_controller;
	public bool m_action;
	private GameManager._ACTION_TYPE m_actionType;

	// Start is called before the first frame update
	private void Start()
	{
		m_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
		m_nav = GameObject.Find("GameManager").GetComponent<Action_Nav>();
		m_debugText = new List<TextMeshProUGUI>();
		Transform vertical_Panel = transform.GetChild(1).GetComponent<Transform>();
		m_debugText.Add(vertical_Panel.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>());
		m_debugText.Add(vertical_Panel.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
		m_debugText.Add(vertical_Panel.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>());
		m_debugText.Add(vertical_Panel.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>());
		m_controller = m_manager.m_controll;
		//m_action = true;
		m_actionType = GameManager._ACTION_TYPE.Repeate;
		m_debugText[0].text = "F1 : Mouse_<color=yellow>GamePad</color>";
		switch (m_action)
		{
			case true:
				m_debugText[1].text = "F2 : None_<color=yellow>Action</color>";
				break;
			case false:
				m_debugText[1].text = "F2 : <color=yellow>None</color>_Action";
				break;
		}
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F12))
		{
			isDebug = !isDebug;
			GetComponent<Canvas>().enabled = isDebug;
		}

		if (!isDebug) return;
		Debug_Controller();
		Debug_Action();
		Debug_ChangeAction();
		Debug_PlayAction();
	}

	// 入力切替
	private void Debug_Controller()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			m_controller++;
			m_controller = (GameManager._ControllType)((int)m_controller % 2);
			switch (m_controller)
			{
				case GameManager._ControllType.Mouse:
					m_manager.m_controll = GameManager._ControllType.Mouse;
					m_debugText[0].text = "F1 : <color=yellow>Mouse</color>_GamePad";
					break;
				case GameManager._ControllType.GamePad:
					m_manager.m_controll = GameManager._ControllType.GamePad;
					m_debugText[0].text = "F1 : Mouse_<color=yellow>GamePad</color>";
					break;
			}
			m_manager.ChangeControll();
		}
	}

	// アクション切り替え
	private void Debug_Action()
	{
		if (Input.GetKeyDown(KeyCode.F2))
		{
			m_action = !m_action;
			switch (m_action)
			{
				case true:
					m_debugText[1].text = "F2 : None_<color=yellow>Action</color>";
					break;
				case false:
					m_debugText[1].text = "F2 : <color=yellow>None</color>_Action";
					break;
			}
		}
	}
	// アクション再生切り替え
	private void Debug_ChangeAction()
	{
		if (Input.GetKeyDown(KeyCode.F3))
		{
			m_actionType++;
			m_actionType = (GameManager._ACTION_TYPE)((int)m_actionType % (int)GameManager._ACTION_TYPE.MAX__);

			m_debugText[2].text = "F3 : Action [<color=yellow>" + m_actionType.ToString() + "</color>] ";
		}
	}
	// アクション再生
	private void Debug_PlayAction()
	{
		if (Input.GetKeyDown(KeyCode.F4))
		{
			switch (m_actionType)
			{
				case GameManager._ACTION_TYPE.Repeate:
					SceneManager.LoadScene("Action_Repeat", LoadSceneMode.Additive);
					//m_nav.m_type.repeate.enabled = true;
					//m_nav.m_type.repeate.m_actDir = true;
					break;
				case GameManager._ACTION_TYPE.Order:
					SceneManager.LoadScene("Action_Order", LoadSceneMode.Additive);
					//m_nav.m_type.order.enabled = true;
					//m_nav.m_type.order.m_actDir = true;
					break;
				case GameManager._ACTION_TYPE.Roll:
					SceneManager.LoadScene("Action_Roll", LoadSceneMode.Additive);
					//m_nav.m_type.timing.enabled = true;
					//m_nav.m_type.timing.m_actDir = true;
					break;
			}
		}
	}
}