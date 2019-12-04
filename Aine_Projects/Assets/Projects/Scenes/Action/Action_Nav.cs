using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MyBox;

public class Action_Nav : MonoBehaviour
{
	[System.Serializable]
	public struct ActionPoint
	{
		public GameManager._ACTION_TYPE m_actionType;
		public float time;
		public bool used;
	}
	//[System.Serializable]
	//public struct ActionType
	//{
	//	public Action_Repeat repeate;
	//	public Action_Order order;
	//	public Action_Timing timing;
	//}
	[SerializeField] private Sprite[] m_icons;
	[SerializeField] private Slider m_slider;
	private GameManager m_manager;
	private Debug_ m_debug;
	//[SerializeField] public ActionType m_type;
	[SerializeField] public List<ActionPoint> ml_action;
	private AudioSource m_audio;
	//[SerializeField] private float m_timeScale;
	[SerializeField] private GameObject m_rectPrefab;

	// Start is called before the first frame update
	private void Start()
	{
		m_manager = GetComponent<GameManager>();
		m_debug = GameObject.Find("Debug__").GetComponent<Debug_>();
		m_audio = GetComponent<AudioSource>();
		// 180 + 55 235
		Generate_Nav();
	}

	// Update is called once per frame
	private void Update()
	{
		m_slider.maxValue = m_manager.m_SoundTime;
		//FastMusic(Input.GetKey(KeyCode.T));
		Action_SliderNav();
		if (m_debug.m_action)
			PlayAction();
	}

	private void Action_SliderNav()
	{
		m_slider.value = m_manager.m_playTime;
	}

	private void Generate_Nav()
	{
		foreach (ActionPoint action in ml_action)
		{
			GameObject rect;
			rect = Instantiate(m_rectPrefab, GameObject.Find("Icon").transform);
			rect.GetComponent<Image>().sprite = m_icons[(int)action.m_actionType];
			rect.GetComponent<RectTransform>().sizeDelta = new Vector2(m_icons[(int)action.m_actionType].texture.width, m_icons[(int)action.m_actionType].texture.height);
			rect.transform.localScale = Vector3.one * .3f;
			rect.GetComponent<RectTransform>().anchoredPosition = new Vector3((750f / m_manager.m_SoundTime) * action.time, 15f, 0f);
		}
	}
	private void PlayAction()
	{
		foreach (ActionPoint action in ml_action)
		{
			if (((int)m_manager.m_playTime == (int)action.time) && (action.used == false))
			{
				ActionPoint work = ml_action.Find(n => (int)n.time == (int)m_manager.m_playTime);
				work.used = true;
				ml_action[ml_action.FindIndex(n => (int)n.time == (int)m_manager.m_playTime)] = work;
				Debug.Log("ACTION : " + action.m_actionType);
				switch (action.m_actionType)
				{
					case GameManager._ACTION_TYPE.Repeate:
						//m_type.repeate.enabled = true;
						//m_type.repeate.m_actDir = true;
						SceneManager.LoadScene("Action_Repeate", LoadSceneMode.Additive);

						break;
					case GameManager._ACTION_TYPE.Order:
						SceneManager.LoadScene("Action_Order", LoadSceneMode.Additive);
						//m_type.order.enabled = true;
						//m_type.order.m_actDir = true;
						break;
					case GameManager._ACTION_TYPE.Timing:
						SceneManager.LoadScene("Action_Timing", LoadSceneMode.Additive);
						//m_type.timing.enabled = true;
						//m_type.timing.m_actDir = true;
						break;
				}
				break;
			}
		}
	}
}